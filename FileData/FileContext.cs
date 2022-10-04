using System.Text.Json;
using Domain.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "redditData.json";
    private DataContainer? dataContainer;

    public ICollection<Reditor> Reditors
    {
        get
        {
            LoadData();
            return dataContainer!.Reditors;
        }
    }

    public ICollection<RedditPost> RedditPosts
    {
        get
        {
            LoadData();
            return dataContainer!.RedditPosts;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;
        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                Reditors = new List<Reditor>(),
                RedditPosts = new List<RedditPost>()
            };
            return;
        }

        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath,serialized);
        dataContainer = null;
    }
}