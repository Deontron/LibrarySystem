using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Data;
using UserService.Domain.Entities;
using UserService.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserService.Services
{
    public class MyUserService : IUserService
    {
        private readonly UserDbContext _context;
        private readonly IConfiguration _config;

        public MyUserService(UserDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt
                }).ToListAsync();
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<UserDto?> UpdateAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.Username = dto.Username;
            user.Email = dto.Email;
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> RegisterAsync(RegisterDto dto)
        {
            var exists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
            if (exists) return null;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
    };

            var token = new JwtSecurityToken(
                issuer: "yourapp",
                audience: "yourapp",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResultDto?> LoginAsync(LoginDto dto)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                    return null;

                var token = GenerateJwtToken(user);

                return new LoginResultDto
                {
                    Token = token,
                    Username = user.Username,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("LOGIN ERROR: " + ex.Message);
                throw;
            }
        }
    }
}
