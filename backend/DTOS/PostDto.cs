namespace backend.DTOs
{
    public class PostDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? postId { get; set; } = null;
    }
}