using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _db;

        public PostService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<PostResponseDto>> GetPostsAsync()
        {
            return await _db.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Select(p => new PostResponseDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    DateCreated = p.DateCreated,
                    AuthorName = p.User.Name,
                    LikeCount = p.Likes.Count,
                    CommentCount = p.Comments.Count
                })
                .ToListAsync();
        }

        public async Task<PostResponseDto> CreatePostAsync(PostDto dto, int userId)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = userId
            };

            _db.Posts.Add(post);
            await _db.SaveChangesAsync();

            var author = await _db.Users.FindAsync(userId);

            return new PostResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                DateCreated = post.DateCreated,
                AuthorName = author!.Name,
                LikeCount = 0,
                CommentCount = 0
            };
        }
    }
}