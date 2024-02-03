namespace HarmonogramyWebAPI.Models;

public class Position
{
    public int Id { get; set; }
    public string PositionName { get; set; }

    public ICollection<User> Users { get; set; }
}