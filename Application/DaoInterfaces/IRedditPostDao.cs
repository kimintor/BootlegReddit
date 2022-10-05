using Domain.Models;

namespace Application.DaoInterfaces;

public interface IRedditPostDao
{
    Task<RedditPost> CreateAsync(RedditPost redditPost);
}