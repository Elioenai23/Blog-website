using backend.DTOs;

namespace backend.Services
{
    // This interface defines the contract for authentication services, including user registration and login functionalities.
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
    }
}