using Microsoft.AspNetCore.Mvc;
using REST.Microservices.Orchestrator.Clients;

namespace REST.Microservices.Orchestrator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrchestratorController : ControllerBase
    {
        private readonly IUserClient _userClient;
        private readonly ILogger<OrchestratorController> _logger;

        public OrchestratorController(ILogger<OrchestratorController> logger, IUserClient userClient)
        {
            _logger = logger;
            _userClient = userClient;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await _userClient.GetUsers(cancellationToken);
            return Ok(result);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
        {
            var result = await _userClient.GetUser(id, cancellationToken);
            return result is not null ? Ok(result) : NotFound("User was not found");
        }
    }
}