using Domain.Models;

namespace FileData;

public class DataContainer
{
    public ICollection<Reditor> Reditors { get; set; }
    public ICollection<RedditPost> RedditPosts { get; set; }
}