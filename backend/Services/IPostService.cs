using backend.DTOs;

namespace backend.Services 
{ 
    public interface IPostService
    {
        Task<List<PostResponseDto>> GetPostsAsync();
        Task<PostResponseDto> CreatePostAsync(PostDto dto, int userId);
        Task<bool> DeletePostAsync(int id, int userId );    }
}
