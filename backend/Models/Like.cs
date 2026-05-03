using backend.Models;
using Microsoft.Win32;
using System.Threading;


namespace backend.Models
{
    public class Like
    {
        public int Id { get; set; }

        //User Fk
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        //Post Fk
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        public bool isLiked { get; set; } = true;
    }
}