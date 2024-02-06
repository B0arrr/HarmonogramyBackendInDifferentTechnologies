namespace HarmonogramyWebAPI.Dto;

public class ScheduleUserDto
{
    public int? Id { get; set; }
    public DateTime? ShiftStart { get; set; }
    public DateTime? ShiftEnd { get; set; }
    public int? ScheduleId { get; set; }
    public int? UserId { get; set; }
}