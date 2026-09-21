using backend.DTOs;

namespace backend.Services
{
    public interface IUserService
    {
        // This interface defines the contract for user-related services, including retrieving, creating, and deleting users.
        Task<List<UserResponseDto>> GetUsersAsync();
        Task<UserResponseDto> CreateUserAsync(UserDto dto);
        Task<bool> DeleteUserAsync(int id);
        //Task<UserResponse?> UpdateUserAsync(UserDto dto, userId); //{Had to comment this out because it cause a lot of errors.}
    }
}
