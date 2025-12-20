using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using backend.Data;
using backend.Models;


[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly AppDbContext _db;
    
    public PostController(AppDbContext context)
    {
        _db = _db;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _db.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .ToListAsync();
        return Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        _db.Posts.Add(post);
        await _db.SaveChangesAsync();
        return Ok(post);
    }
}