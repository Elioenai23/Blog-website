using backend.DTOs;

namespace backend.Services
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetUsersAsync();
        Task<UserResponseDto> CreateUserAsync(UserDto dto);
        Task<bool> DeleteUserAsync(int id);
    }
}
