namespace Domain.DTOs;

public class ReditorCreationDto
{
    public string UserName { get; }

    public ReditorCreationDto(string userName)
    {
        UserName = userName;
    }
}