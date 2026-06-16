namespace backend.DTOs


{
	public class PostResponseDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
		public string Content { get; set; } = string.Empty;
		public DateTimeOffset DateCreated { get; set; }
		public string AuthorName { get; set; } = string.Empty;
		public int LikeCount { get; set; }
		public int CommentCount { get; set; }
		}
	}