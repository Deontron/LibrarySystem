namespace UserService.Dtos
{
    public class LoginResultDto
    {
        public string Token { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
    }

}
