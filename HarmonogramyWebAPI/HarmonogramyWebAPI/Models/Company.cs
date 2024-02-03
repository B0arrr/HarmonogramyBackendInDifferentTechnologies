namespace HarmonogramyWebAPI.Models;

public class Company
{
    public int Id { get; set; }
    public string CompanyName { get; set; }

    public ICollection<User> Users { get; set; }
}