﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class RedditPost
{
   
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    
    public Reditor PostOwner { get; set; }
    public string Body { get; set; }
    public int upvotes { get; set; }
    public int  downvotes { get; set; }

    public RedditPost(Reditor postOwner, string title,string body)
    {
        PostOwner = postOwner;
        Title = title;
        Body = body;

    }

    public RedditPost()
    {
    }
}