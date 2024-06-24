using BestPractices.Application.Interfaces;
using BestPractices.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.API.Controllers;

/// <summary>
/// Controller do Cliente
/// </summary>
[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService clientService;
    private readonly ILogger<ClientController> logger;

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="clientService"></param>
    public ClientController(IClientService clientService, ILogger<ClientController> logger)
    {
        this.clientService = clientService;
        this.logger = logger;
    }

    /// <summary>
    /// Registra um cliente na base de dados.
    /// </summary>
    /// <param name="clientRequest"> Objeto com os dados do cliente. </param>
    /// <response code="200">Retorna que o cliente foi registrado com sucesso.</response>
    /// <response code="500">Retorna o erro especifico. </response>
    [HttpPost("Login")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterClient([FromBody] ClientRequest clientRequest)
    {
        logger.LogInformation($"{nameof(ClientController)} - Starting process to register customer");

        if (string.IsNullOrEmpty(clientRequest.Name) || string.IsNullOrEmpty(clientRequest.Email) || clientRequest.PhoneNumber.Equals(null))
            return BadRequest(new { Message = "Informe todos os dados do registro do cliente" });

        return Ok(await clientService.RegisterClient(clientRequest));
    }
}