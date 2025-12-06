using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Users
        public DbSet<User> Users { get; set; }

       //Post
       public DbSet<Post> Posts { get; set; }

        //Likes
        public DbSet<Like> Likes { get; set; }

        //Comments
        public DbSet<Comment> Comments { get; set; }

    }

   
}