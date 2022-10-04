using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IReditorInterface
{
    Task<Reditor> CreateAsync(ReditorCreationDto reditorToCreate);
}