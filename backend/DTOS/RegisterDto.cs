using System.ComponentModel.DataAnnotations;

namespace backend.DTOs

{
    public class RegisterDto

    {
        // DTO for user registration. This will be used to send the user's registration data from the client to the server.
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        public string Bios { get; set; } = string.Empty;
    }
}