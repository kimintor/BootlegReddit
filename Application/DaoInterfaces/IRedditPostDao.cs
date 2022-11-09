using System.Net.NetworkInformation;
using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IRedditPostDao
{
    Task<RedditPost> CreateAsync(RedditPost redditPost);

    public Task<IEnumerable<PostTitleDto>> GetPostTitles();

    public Task<IEnumerable<RedditPost>> GetPosts();

    public Task<RedditPost> GetPostByID(int id);

}