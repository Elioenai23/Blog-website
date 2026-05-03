using backend.Models;
using Microsoft.Win32;
using System.Collections.Generic;

namespace backend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; 
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        //Post Description
        public string? Description { get; set; } = string.Empty; //optional preview text

        //User Fk
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        //Likes and Comments
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Like> Likes { get; set; } = new List<Like>();

    }
}



