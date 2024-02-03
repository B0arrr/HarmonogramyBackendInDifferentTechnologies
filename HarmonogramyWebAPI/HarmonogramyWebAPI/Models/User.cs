using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonogramyWebAPI.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public bool IsSuperUser { get; set; }
    public bool IsEmpoyed { get; set; }
    public DateOnly DateOfEmployment { get; set; }
    public DateOnly? DateOfFired { get; set; }
    
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }
    
    public int? EmploymentId { get; set; }
    public Employment? Employment { get; set; }
    
    public int? PositionId { get; set; }
    public Position? Position { get; set; }

    public ICollection<ScheduleUser> Schedules { get; set; }
}