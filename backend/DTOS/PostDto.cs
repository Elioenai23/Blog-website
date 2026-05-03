namespace backend.DTOs
{
    public class PostDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? Id { get; set; } = null;
    }
}