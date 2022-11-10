namespace Domain.Models;

public class Reditor
{
    public int Id { get; set; }
    public string Username { get; set; }

    public string Password { get; set; }

    public Reditor()
    {
        Id = 5;
        Username = "admin";
        Password = "admin";
    }
}