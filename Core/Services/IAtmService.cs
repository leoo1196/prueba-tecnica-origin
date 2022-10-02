using Core.Dtos;
using Core.Results;

namespace Core.Services;
public interface IAtmService
{
    /// <summary>
    /// A traves del número proveido valida la existencia de la tarjeta, y que no se encuentre bloqueada
    /// ni vencida. Si alguna validación falla, retorna un error, de lo contrario el mismo número de la tarjeta.
    /// </summary>
    /// <param name="cardNumberInput">Inpunt con el número de la tarjeta.</param>
    /// <returns>Un <see cref="Result"/> con el resultado de la validación.</returns>
    Task<Result<string>> ValidateCardNumberAsync(CardNumberInputDto cardNumberInput);

    /// <summary>
    /// Valida que el número de la tarjeta corresponda con el pin. Si alguna validación falla, retorna un error,
    /// de lo contrario devuelve el id de la tarjeta. Si se supera el limite de intentos la tarjeta se bloquea.
    /// </summary>
    /// <param name="pinInput">Entrada con número y pin.</param>
    /// <returns>Un <see cref="Result"/> con el resultado de la validación.</returns>
    Task<Result<ValidatedCard>> ValidatePinAsync(PinInputDto pinInput);

    /// <summary>
    /// Obtiene los datos de la tarjeta a partir del id. Además registra la operación.
    /// </summary>
    /// <param name="getBalanceInput">Id de la tarjeta.</param>
    /// <returns>Objeto <see cref="BalanceDto"/> con la información del balance.</returns>
    Task<Result<BalanceDto>> GetBalanceAsync(GetBalanceInputDto getBalanceInput);

    /// <summary>
    /// Procesa la petición de extracción y si es correcta actualiza el balance de la tarjeta. Además registra la operación.
    /// </summary>
    /// <param name="extractionInput">Input con Id de la tarjeta y monto solicitado.</param>
    /// <returns>Objeto <see cref="OperationFinishedDto"/> con el id de la operación.</returns>
    Task<Result<OperationFinishedDto>> ProcessExtractionAsync(ExtractionInputDto extractionInput);

    /// <summary>
    /// Obtiene información de una operación realizada a traves de su id.
    /// </summary>
    /// <param name="operationId">Id de la operación.</param>
    /// <returns>Objeto <see cref="OperationDto"/> con la información de la operación.</returns>
    Task<Result<OperationDto>> GetOperationById(Guid operationId);
}
