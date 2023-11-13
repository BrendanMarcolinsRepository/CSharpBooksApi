namespace Books.Models.DTOs.AuthDto
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
    }
}
