namespace ViteNetCoreApp.Domain.Models.DTOs
{
    public class LoginResponseDto
    {
        public int userId { get; set; }
        public required string token { get; set; }
        public required string email { get; set; }
        public required string name { get; set; }
    }
}
