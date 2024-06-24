using BestPractices.Application.Interfaces;
using BestPractices.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost]
        public IActionResult RegisterClient([FromBody] ClientRequest clientRequest)
        {
            var registered = clientService.RegisterClient(clientRequest);

            return Ok(registered);
        }
    }
}
