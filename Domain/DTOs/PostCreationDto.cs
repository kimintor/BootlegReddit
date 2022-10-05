namespace Domain.DTOs;

public class PostCreationDto
{
    public int OwnerID { get; }
    public string Title { get; }
    public string Body { get; set; }

    public PostCreationDto(int ownerId, string title, string body)
    {
        OwnerID = ownerId;
        Title = title;
        Body = body;
    }
}