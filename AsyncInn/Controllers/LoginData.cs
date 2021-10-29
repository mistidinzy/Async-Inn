using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Controllers
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}