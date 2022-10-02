using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Extensions;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AtmController : ControllerBase
{
    private readonly IAtmService _atmService;

	public AtmController(IAtmService atmService)
	{
		_atmService = atmService;
	}

    [HttpPost("validate-card")]
    public async Task<IActionResult> ValidateCardNumber([FromBody] CardNumberInputDto cardNumberInput)
    {
        var result = await _atmService.ValidateCardNumberAsync(cardNumberInput);
        return result.ToStatusCodeActionResult();
    }

    [HttpPost("validate-pin")]
    public async Task<IActionResult> ValidatePin([FromBody] PinInputDto pinInput)
    {
        var result = await _atmService.ValidatePinAsync(pinInput);
        return result.ToStatusCodeActionResult();
    }

    [HttpPost("balance")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BalanceDto))]
    public async Task<IActionResult> GetBalance([FromBody] GetBalanceInputDto getBalanceInput)
    {
        var result = await _atmService.GetBalanceAsync(getBalanceInput);
        return result.ToStatusCodeActionResult();
    }

    [HttpPost("extraction")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperationFinishedDto))]
    public async Task<IActionResult> Extraction([FromBody] ExtractionInputDto extractionInput)
    {
        var result = await _atmService.ProcessExtractionAsync(extractionInput);
        return result.ToStatusCodeActionResult();
    }

    [HttpGet("operation/{operationId}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperationDto))]
    public async Task<IActionResult> GetOperation([FromRoute] Guid operationId)
    {
        var result = await _atmService.GetOperationById(operationId);
        return result.ToStatusCodeActionResult();
    }
}
