namespace HarmonogramyWebAPI.Models;

public class Schedule
{
    public int Id { get; set; }
    public DateOnly StartDay { get; set; }
    public bool DayOff { get; set; }

    public ICollection<ScheduleUser> Users { get; set; }
}