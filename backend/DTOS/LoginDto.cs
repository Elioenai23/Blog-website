using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class LoginDto   
    {
        // DTO for user login. I think this is all that's needed.
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}