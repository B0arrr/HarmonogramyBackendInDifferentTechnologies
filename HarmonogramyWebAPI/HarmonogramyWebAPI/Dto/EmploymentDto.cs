namespace HarmonogramyWebAPI.Dto;

public class EmploymentDto
{
    public int? Id { get; set; }
    public string? EmploymentName { get; set; }
    public int? MaxHoursPerWeek { get; set; }
    public int? MaxHoursPerDay { get; set; }
}