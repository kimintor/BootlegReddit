using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
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

    public async Task<RedditPost> CreatePostAsync(PostCreationDto post)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post", post);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        RedditPost postToReturn = JsonSerializer.Deserialize<RedditPost>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return postToReturn;
    }
}