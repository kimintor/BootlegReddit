using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess_A.DAOs;

public class RedditPostEfcDao: IRedditPostDao
{
    private readonly RedditContext context;

    public RedditPostEfcDao(RedditContext context)
    {
        this.context = context;
    }
    public async Task<RedditPost> CreateAsync(RedditPost redditPost)
    {
        EntityEntry<RedditPost> newRedditPost = await context.Posts.AddAsync(redditPost);
        await context.SaveChangesAsync();
        return newRedditPost.Entity;
    }

    public Task<IEnumerable<PostTitleDto>> GetPostTitles()
    {
        List<RedditPost> posts = context.Posts.AsEnumerable().ToList();
        List<PostTitleDto> result = new List<PostTitleDto>();
        for (int i = 0; i < posts.Count; i++)
        {
            result.Add(new PostTitleDto(posts[i].Title));
        }
        
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<IEnumerable<RedditPost>> GetPosts()
    {
        List<RedditPost> posts = context.Posts.Include(p=>p.PostOwner).AsEnumerable().ToList();
      
        
        return Task.FromResult(posts.AsEnumerable());
    }

    public async Task<RedditPost> GetPostByID(int id)
    {
        RedditPost existing =
            await context.Posts.Include(p=>p.PostOwner).FirstOrDefaultAsync(p => p.Id == id);

        return existing;
    }
}