namespace backend.DTOs


{
    public class UserResponseDto
    {
        // DTO for user response. This will be used to send the user data from the server to the client.
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Bios { get; set; } = string.Empty;
    }
}
    