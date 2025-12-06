using backend.Models;
using Microsoft.Win32;
using System.Security.Policy;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }
}