using System.Collections.Generic;

namespace backend.Models
{
    public class User
    {
        //Basic User Models
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;  
        
        //Password Hash
        public string PasswordHash { get; set; } = string.Empty;

        //Personal User Bio
        public string Bios { get; set; } = string.Empty;

        //Posts
        public List<Post> Posts { get; set; } = new List<Post>();

        //Likes and Comments
        public List<Like> Likes { get; set; } = new List<Like> ();
        public List<Comment> Comments { get; set; }=new List<Comment>();

        public List<Subscription> Subscribers { get; set; } = new List<Subscription>();
        public List<Subscription> SubscribedTo { get; set; } = new List<Subscription>();
    }
}