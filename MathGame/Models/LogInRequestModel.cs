using System.ComponentModel.DataAnnotations;

namespace MathGame.Models
{
    public class LogInRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
