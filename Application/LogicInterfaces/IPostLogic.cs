using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<RedditPost> CreateAsync(PostCreationDto dto);

    public Task<IEnumerable<PostTitleDto>> GetPostTitles();

    public Task<IEnumerable<RedditPost>> GetPosts();

    public Task<RedditPost> GetByID(int id);
}