using Domain.DTOs;
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

    public Task<IEnumerable<PostTitleDto>> GetPostTitles()
    {
        List<RedditPost> posts = context.RedditPosts.AsEnumerable().ToList();
        List<PostTitleDto> result = new List<PostTitleDto>();
        for (int i = 0; i < posts.Count; i++)
        {
            result.Add(new PostTitleDto(posts[i].Title));
        }
        
        return Task.FromResult(result.AsEnumerable());
        
    }

    public Task<IEnumerable<RedditPost>> GetPosts()
    {
        List<RedditPost> posts = context.RedditPosts.AsEnumerable().ToList();
      
        
        return Task.FromResult(posts.AsEnumerable());
    }

    public Task<RedditPost> GetPostByID(int id)
    {
        RedditPost? exisiting = context.RedditPosts.First(
            p => p.Id == id);

        return Task.FromResult(exisiting);
    }
}