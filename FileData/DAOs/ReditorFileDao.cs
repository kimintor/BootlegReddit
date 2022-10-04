using System.Net.Mime;
using Application.DaoInterfaces;
using Domain.Models;

namespace FileData.DAOs;


public class ReditorFileDao:IReditorDao
{
    private readonly FileContext context;

    public ReditorFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Reditor> CreateAsync(Reditor reditor)
    {
        int userId = 1;
        if (context.Reditors.Any())
        {
            userId = context.Reditors.Max(r => r.Id);
            userId++;
        }

        reditor.Id = userId;
        
        context.Reditors.Add(reditor);
        context.SaveChanges();

        return Task.FromResult(reditor);
    }

    public Task<Reditor?> GetByUsernameAsync(string username)
    {
        Reditor? existing = context.Reditors.FirstOrDefault(
            r => r.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(existing);
    }
}