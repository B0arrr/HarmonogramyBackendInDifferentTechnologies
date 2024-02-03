namespace HarmonogramyWebAPI.Models;

public class Employment
{
    public int Id { get; set; }
    public string EmploymentName { get; set; }
    public int MaxHoursPerWeek { get; set; }
    public int MaxHoursPerDay { get; set; }

    public ICollection<User> Users { get; set; }
}