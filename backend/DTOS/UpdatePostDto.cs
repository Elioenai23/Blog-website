//New Dto for updating posts.

namespace backend.DTOs
{
     public class UpdatePostDto
    {
        // DTO for updating a post. This will be used to send the post data from the client to the server.
            public string Title { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public int? postId { get; set; } = null;
            public string Description { get; set; } = string.Empty;
    }
}
