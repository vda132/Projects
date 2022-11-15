using Microsoft.AspNetCore.Mvc;
using REST.Microservices.UserMS.MockData;

namespace REST.Microservices.UserMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation($"Fetching all users in {nameof(UsersController)} get endpoint");
            return Ok(await _userService.GetUsers());
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"Fetching user with id {id} in {nameof(UsersController)} get by id endpoint");
            var user = await _userService.GetUser(id);
            
            return user is not null ? Ok(user) : NotFound("User was not found");
        }
    }
}