using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient:IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Reditor> Create(ReditorCreationDto dto)
    {

        HttpResponseMessage response = await client.PostAsJsonAsync("/Reditor", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Reditor reditor = JsonSerializer.Deserialize<Reditor>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return reditor;
    }
}