using Domain.Models;

namespace FileData.DAOs;
using Application.DaoInterfaces;

public class RedditPostDao:IRedditPostDao
{
    private readonly FileContext context;

    public RedditPostDao(FileContext context)
    {
        this.context = context;
    }

    public Task<RedditPost> CreateAsync(RedditPost redditPost)
    {
        int id = 1;
        if (context.RedditPosts.Any())
        {
            id = context.RedditPosts.Max(p => p.Id);
            id++;
        }

        redditPost.Id = id;
        
        context.RedditPosts.Add(redditPost);
        context.SaveChanges();

        return Task.FromResult(redditPost);
    }
}