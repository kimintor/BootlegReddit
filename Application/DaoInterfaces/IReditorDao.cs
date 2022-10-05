using Domain.Models;

namespace Application.DaoInterfaces;

public interface IReditorDao
{
    Task<Reditor> CreateAsync(Reditor reditor);
    Task<Reditor?> GetByUsernameAsync(string username);

    Task<Reditor?> GetByIdAsync(int id);
}