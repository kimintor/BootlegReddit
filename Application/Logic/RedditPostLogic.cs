using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class RedditPostLogic:IPostLogic
{
    private readonly IRedditPostDao postDao;
    private readonly IReditorDao reditorDao;

    public RedditPostLogic(IReditorDao reditorDao, IRedditPostDao postDao)
    {
        this.postDao = postDao;
        this.reditorDao = reditorDao;

    }

    public async Task<RedditPost> CreateAsync(PostCreationDto dto)
    {
        Reditor? reditor = await reditorDao.GetByIdAsync(dto.OwnerID);

        if (reditor==null)
        {
            throw new Exception($"Reditor with id{dto.OwnerID} was not found");
        }
        ValidateRedditPost(dto);
        RedditPost redditPost = new RedditPost(reditor, dto.Title,dto.Body);
        RedditPost created = await postDao.CreateAsync(redditPost);
        return created;

    }

    public Task<IEnumerable<PostTitleDto>> GetPostTitles()
    {
        return postDao.GetPostTitles();
    }

    private void ValidateRedditPost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new Exception("Title cannot be empty");
        }

        if (string.IsNullOrEmpty(dto.Body))
        {
            throw new Exception("Body cannot be empty");
        }
    }
}