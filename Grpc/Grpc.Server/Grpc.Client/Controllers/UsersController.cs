using Grpc.Client.GrpcClientService;
using Microsoft.AspNetCore.Mvc;

namespace Grpc.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() =>
            Ok(await _userService.GetUsersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);

            return user is null ? NotFound($"The user with id:{id} was not found") : Ok(user);
        }
    }
}