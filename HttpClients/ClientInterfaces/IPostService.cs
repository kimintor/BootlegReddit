using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<ICollection<RedditPost>> GetAsync();

    Task<RedditPost> GetByID(int id);
}