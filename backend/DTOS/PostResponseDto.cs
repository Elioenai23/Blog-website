namespace backend.DTOs


{
	public class PostResponseDto
	{
        // DTO for sending post data back to the client. This will be used to send the post data from the server to the client.
        public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public DateTimeOffset DateCreated { get; set; }
		public string AuthorName { get; set; } = string.Empty;
		public int LikeCount { get; set; }
		public int CommentCount { get; set; }
		}
	}