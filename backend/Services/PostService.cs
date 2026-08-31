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

        public async Task<PostResponseDto?> GetPostByIdAsync(int id)
        {
            return await _db.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Where(p => p.Id == id)
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
        .FirstOrDefaultAsync();
      
        }
        public async Task<PostResponseDto> CreatePostAsync(PostDto dto, int userId)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = userId,
                Description = dto.Description
            };

            _db.Posts.Add(post);
            await _db.SaveChangesAsync();

            var author = await _db.Users.FindAsync(userId);

            return new PostResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Description= post.Description,
                Content = post.Content,
                DateCreated = post.DateCreated,
                AuthorName = author!.Name,
                LikeCount = 0,
                CommentCount = 0
            };

        }
        public async Task<bool> DeletePostAsync(int postId, int userId)
        {
            var post = await _db.Posts.FindAsync(postId);
            if (post == null || post.UserId != userId)
            {
                return false;
            }

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            return true;

           
        }
        
    }
}