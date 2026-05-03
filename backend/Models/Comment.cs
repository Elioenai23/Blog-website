using backend.Models;
using Microsoft.Win32;
using System.Security.Policy;

namespace backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;

        //User Fk
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        //Post Fk
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        public DateTime CommentedOn { get; set; } = DateTime.UtcNow;
    }
}