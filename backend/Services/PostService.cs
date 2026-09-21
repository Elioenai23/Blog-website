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

        public async Task<List<PostResponseDto>> GetPostsAsync() // Retrieve all posts with their associated user, likes, and comments
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

        public async Task<PostResponseDto?> GetPostByIdAsync(int id) // Retrieve a single post by its ID with its associated user, likes, and comments
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
        public async Task<PostResponseDto> CreatePostAsync(PostDto dto, int userId) // Create a new post and return its details
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
        public async Task<bool> DeletePostAsync(int postId, int userId) // Delete a post if it exists and belongs to the user
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

        //Supposed to update the post
        public async Task<PostResponseDto> UpdatePostAsync(int id, PostDto dto, int userId)
        {
            var updatePost = await _db.Posts.FindAsync(id);
            if (updatePost == null || updatePost.UserId != userId)
            {
                return null;
            }

            updatePost.Title = dto.Title;
            updatePost.Description = dto.Description;
            updatePost.Content = dto.Content;

            await _db.SaveChangesAsync();

            var author = await _db.Users.FindAsync(userId);

            return new PostResponseDto
            {
                Id = updatePost.Id,
                Title = updatePost.Title,
                Description = updatePost.Description,
                Content = updatePost.Content,
                DateCreated = updatePost.DateCreated,
                AuthorName = author!.Name,
                LikeCount = updatePost.Likes.Count,
                CommentCount = updatePost.Comments.Count
            };  
        }
        
    }
}