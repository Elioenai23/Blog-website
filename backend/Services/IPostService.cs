using backend.DTOs;
using System.Security.Claims;

namespace backend.Services 
{ 
    public interface IPostService
    {
        Task<List<PostResponseDto>> GetPostsAsync();
        Task<PostResponseDto> CreatePostAsync(PostDto dto, int userId);
    }
}
