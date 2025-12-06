namespace backend.Models
{
    public class User
    {
        //Basic User Models
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        //Password Field
        public string Password { get; set; }

        //Personal User Bio
        public string Bios { get; set; }

        //Posts
        public List<Post> Posts { get; set; } = new();

        //Likes and Comments
        public List<Like> Likes { get; set; } = new();
        public List<Comment> Comments { get; set; }=new();
    }
}