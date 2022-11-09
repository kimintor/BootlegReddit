using System.Text.Json;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<RedditPost>> GetAsync()
    {
        HttpResponseMessage message = await client.GetAsync("/Post");
        string content = await message.Content.ReadAsStringAsync();

        if (!message.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<RedditPost> result = JsonSerializer.Deserialize<ICollection<RedditPost>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return result;
    }

    public async Task<RedditPost> GetByID(int id)
    {
        HttpResponseMessage message = await client.GetAsync($"Post/{id}");
        string content = await message.Content.ReadAsStringAsync();

        if (!message.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        RedditPost result = JsonSerializer.Deserialize<RedditPost>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true

        })!;
        return result;
    }
}