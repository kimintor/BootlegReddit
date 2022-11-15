using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess_A.DAOs;

public class RedditorEfcDAO : IReditorDao
{
    private readonly RedditContext context;

    public RedditorEfcDAO(RedditContext context)
    {
        this.context = context;
    }

    public async Task<Reditor> CreateAsync(Reditor reditor)
    {
        EntityEntry<Reditor> newReditor = await context.Reditors.AddAsync(reditor);
        await context.SaveChangesAsync();
        return newReditor.Entity;
    }

    public async Task<Reditor?> GetByUsernameAsync(string username)
    {
        Reditor existing =
            await context.Reditors.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

        return existing;
    }

    public async Task<Reditor?> GetByIdAsync(int id)
    {
        Reditor existing = await context.Reditors.FirstOrDefaultAsync(u => u.Id == id);
        return existing;
    }
}