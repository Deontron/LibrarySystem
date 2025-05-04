namespace UserService.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }

}
