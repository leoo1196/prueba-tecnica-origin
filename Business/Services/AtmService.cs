using Core.Configuration;
using Core.Dtos;
using Core.Errors;
using Core.Extensions;
using Core.Models;
using Core.Repositories;
using Core.Results;
using Core.Services;
using Microsoft.Extensions.Options;

namespace Business.Services;
public class AtmService : IAtmService
{
    private readonly AppConfig _config;
    private readonly ICardRepository _cardRepository;
    private readonly IOperationRepository _operationRepository;

    private const string cardDoesNotExists = "Tarjeta no encontrada";
    private const string cardLocked = "La tarjeta se encuentra bloqueada";
    private const string cardExpired = "La tarjeta se encuentra vencida";
    private const string invalidPin = "Pin incorrecto";
    private const string invalidAmount = "El monto excede el balance de la cuenta";
    private const string lockedByInvalidPin = "La tarjeta ha sido bloqueada";
    private const string operationDoesNotExists = "La operación no existe";

    public AtmService(IOptions<AppConfig> appConfig, ICardRepository cardRepository, IOperationRepository operationRepository)
    {
        _config = appConfig.Value;
        _cardRepository = cardRepository;
        _operationRepository = operationRepository;
    }

    public async Task<Result<BalanceDto>> GetBalanceAsync(GetBalanceInputDto getBalanceInput)
    {
        var card = await _cardRepository.GetByIdAsync(getBalanceInput.CardId);

        return await ValidateCard(card)
            .Then(e => SaveOperationAsync(e, Core.Enums.OperationType.Balance, null))
            .Then(operation => Result<BalanceDto>.FromModel(new()
            {
                Balance = operation.Card.Balance,
                CardNumber = operation.Card.Number,
                DueDate = operation.Card.DueDate
            }));
    }

    public async Task<Result<OperationDto>> GetOperationById(Guid operationId)
    {
        var operation = await _operationRepository.GetFullOperationAsync(operationId);

        if (operation is null)
            return new NotFoundError(operationDoesNotExists);

        return new OperationDto
        {
            Balance = operation.Card.Balance,
            CardNumber = operation.Card.Number,
            ExtractionAmount = operation.Amount,
            OperationTime = operation.CreatedAt
        };
    }

    public async Task<Result<OperationFinishedDto>> ProcessExtractionAsync(ExtractionInputDto extractionInput)
    {
        var (cardId, amount) = extractionInput;
        var card = await _cardRepository.GetByIdAsync(cardId);

        return await ValidateCard(card)
            .Then(e => ValidateExtractionAmount(e, amount))
            .Then(e => UpdateCardBalanceAsync(e, amount))
            .Then(e => SaveOperationAsync(e, Core.Enums.OperationType.Extraction, amount))
            .Then(operation => Result<OperationFinishedDto>.FromModel(new()
            {
                OperationId = operation.Id
            }));
    }

    public async Task<Result<string>> ValidateCardNumberAsync(CardNumberInputDto cardNumberInput)
    {
        var card = await _cardRepository.GetByNumberAsync(cardNumberInput.CardNumber);

        return ValidateCard(card).Then(e => Result<string>.FromModel(e.Number));
    }

    public async Task<Result<ValidatedCard>> ValidatePinAsync(PinInputDto pinInput)
    {
        var (cardNumber, pin) = pinInput;
        var card = await _cardRepository.GetByNumberAsync(cardNumber);

        return await ValidateCard(card)
            .Then(e => ProcessPinInputAsync(e, pin))
            .Then(e => Result<ValidatedCard>.FromModel(new ValidatedCard { CardId = e.Id }));
    }

    private static Result<Card> ValidateCard(Card? card)
    {
        if (card is null)
            return new NotFoundError(cardDoesNotExists);

        if (card.IsLocked)
            return new BadRequestError(cardLocked);

        if (card.DueDate < DateTime.Now)
            return new BadRequestError(cardExpired);

        return card;
    }

    private async Task<Result<Card>> ProcessPinInputAsync(Card card, string pin)
    {
        if (card.Pin == pin)
            return card;

        if (++card.Attempts == _config.MaxNumberOfAttempts)
            card.IsLocked = true;

        await _cardRepository.UpdateAsync(card);
        return card.IsLocked ? new ConflictError(lockedByInvalidPin) : new BadRequestError(invalidPin);
    }

    private async Task<Result<Operation>> SaveOperationAsync(Card card, Core.Enums.OperationType operationType, decimal? amount)
    {
        var operation = new Operation
        {
            Id = Guid.NewGuid(),
            OperationTypeId = (int)operationType,
            Card = card,
            Amount = amount
        };

        await _operationRepository.InsertAsync(operation);
        return operation;
    }

    private static Result<Card> ValidateExtractionAmount(Card card, decimal amount)
    {
        if (card.Balance < amount)
            return new BadRequestError(invalidAmount);

        return card;
    }

    private async Task<Result<Card>> UpdateCardBalanceAsync(Card card, decimal amount)
    {
        card.Balance -= amount;
        await _cardRepository.UpdateAsync(card);

        return card;
    }
}
