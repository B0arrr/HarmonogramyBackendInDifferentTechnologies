namespace HarmonogramyWebAPI.Models;

public class ScheduleUser
{
    public int Id { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}