using backend.DTOs;

namespace backend.Services
{
    public interface IPostService
    {
        // This interface defines the contract for post services, including functionalities to get, create, delete, and update posts.
        Task<List<PostResponseDto>> GetPostsAsync();
        Task<PostResponseDto> CreatePostAsync(PostDto dto, int userId);
        Task<bool> DeletePostAsync(int id, int userId);
        Task<PostResponseDto?> GetPostByIdAsync(int id);
        Task<PostResponseDto?> UpdatePostAsync(PostDto dto, int userId);
    }
}