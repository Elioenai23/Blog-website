using backend.Models;
using Microsoft.Win32;
using System.Collections.Generic;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    //Post Description
    public string? Description { get; set; } //optional preview text

    //User Fk
    public int UserId { get; set; }
    public User User { get; set; }

    //Likes and Comments
    public List<Comment> Comments { get; set; } = new();
    public List<Like> Likes { get; set; } = new();

}

