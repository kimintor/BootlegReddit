using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class Reditor
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }

    public string Password { get; set; }
   
    [JsonIgnore]
    public ICollection<RedditPost> Posts { get; set; }

    public Reditor()
    {
       
        Username = "admin";
        Password = "admin";
    }
}