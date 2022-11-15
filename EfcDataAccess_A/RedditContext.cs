using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess_A;

public class RedditContext:DbContext
{
    public DbSet<Reditor> Reditors { get; set; }
    public DbSet<RedditPost> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess_A/Reddit.db");
    }
}