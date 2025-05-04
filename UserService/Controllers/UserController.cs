using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var user = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserDto dto)
        {
            var user = await _userService.UpdateAsync(id, dto);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _userService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
