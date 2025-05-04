using UserService.Domain.Entities;
using UserService.Dtos;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<UserDto?> UpdateAsync(Guid id, UpdateUserDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<User?> RegisterAsync(RegisterDto dto);
        Task<LoginResultDto?> LoginAsync(LoginDto dto);
    }
}
