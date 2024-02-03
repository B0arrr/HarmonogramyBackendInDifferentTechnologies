using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.DbInitializer;

public class DatabaseContextInitializer(IContext context)
{
    public async Task Run()
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.Companies.Any())
        {
            context.Companies.Add(new Company { CompanyName = "Test" });
        }

        if (!context.Employments.Any())
        {
            context.Employments.Add(new Employment
            {
                EmploymentName = "Test",
                MaxHoursPerDay = 8,
                MaxHoursPerWeek = 40
            });
        }

        if (!context.Positions.Any())
        {
            context.Positions.Add(new Position { PositionName = "Test" });
        }

        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                FirstName = "Test",
                LastName = "Test",
                Email = Environment.GetEnvironmentVariable("FirstSuperuserEmail")!,
                Password = Security.GetPasswordHash(Environment.GetEnvironmentVariable("FirstSuperuserPassword")!),
                IsActive = true,
                IsSuperUser = true,
                IsEmpoyed = true,
                DateOfEmployment = DateOnly.FromDateTime(DateTime.Now),
                CompanyId = context.Companies.FirstOrDefault()?.Id,
                EmploymentId = context.Employments.FirstOrDefault()?.Id,
                PositionId = context.Positions.FirstOrDefault()?.Id
            });
        }
        
        await context.SaveChangesAsync();
    }
}