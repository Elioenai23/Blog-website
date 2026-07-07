using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _postService.GetPostsAsync();
        return Ok(posts);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePost(PostDto dto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); //need to figure out how to implement int.TryParse here to avoid exception if userId is not an int
        var post = await _postService.CreatePostAsync(dto, userId);


        return Ok(post);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var success = await _postService.DeletePostAsync(id, userId);
        if (!success)
            return NotFound("Post not found or not owned by user");

        return Ok("Post deleted successfully");
    }
}