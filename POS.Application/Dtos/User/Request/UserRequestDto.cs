using Microsoft.AspNetCore.Http;

namespace POS.Application.Dtos.User.Request
{
    public class UserRequestDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public IFormFile? Image { get; set; }
        public string? AuthType { get; set; }
        public int? State { get; set; }
    }
}