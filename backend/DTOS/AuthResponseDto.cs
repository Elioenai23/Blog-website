namespace backend.DTOs
{
    public class AuthResponseDto
    {
        //DTO for authentication response. This will be used to send back the token and user information after successful login or registration.
        public string Token { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Bios { get; set; } = string.Empty;
    }
}