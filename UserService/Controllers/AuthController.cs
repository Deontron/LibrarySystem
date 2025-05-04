using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            if (user == null)
                return BadRequest("Email already in use");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            if (result == null)
                return Unauthorized();

            return Ok(result); // içinde Token, Username vs. var
        }
    }
}
