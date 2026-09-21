namespace backend.DTOs
{
    public class UserDto
    {
        // DTO for user information. This will be used to send the user data from the client to the server.
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? userId { get; set; } = null;
        public string Bios { get; set; } = string.Empty;
    }
}