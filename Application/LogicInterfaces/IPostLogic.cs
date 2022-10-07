using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<RedditPost> CreateAsync(PostCreationDto dto);

    public Task<IEnumerable<PostTitleDto>> GetPostTitles();
}