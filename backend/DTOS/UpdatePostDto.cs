namespace backend.DTOs
{
     public class UpdatePostDto
    {
       
            public string Title { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public int? postId { get; set; } = null;
            public string Description { get; set; } = string.Empty;
    }
}
