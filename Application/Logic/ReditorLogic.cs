using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class ReditorLogic:IReditorInterface
{
    private readonly IReditorDao reditorDao;

    public ReditorLogic(IReditorDao reditorDao)
    {
        this.reditorDao = reditorDao;
    }

    public async Task<Reditor> CreateAsync(ReditorCreationDto dto)
    {
        Reditor? existing = await reditorDao.GetByUsernameAsync(dto.UserName);
        if (existing!=null)
        {
            throw new Exception("Username already Taken!");
        }

        ValidateData(dto);

        Reditor reditorToCreate = new Reditor
        {
            Username = dto.UserName
        };

        Reditor created = await reditorDao.CreateAsync(reditorToCreate);

        return created;

    }

    private static void ValidateData(ReditorCreationDto reditorToCreate)
    {
        string userName = reditorToCreate.UserName;

        if (userName.Length<3)
        {
            throw new Exception("Username must me at least 3 characters");
        }

        if (userName.Length>20)
        {
            throw new Exception("Username must be less than 20 characters");
        }
    }
}