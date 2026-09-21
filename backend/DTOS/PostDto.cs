namespace backend.DTOs
{
    public class PostDto

    {
        // DTO for creating or updating a post. This will be used to send the post data from the client to the server.
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? postId { get; set; } = null;
        public string Description { get; set; } = string.Empty;
    }
}