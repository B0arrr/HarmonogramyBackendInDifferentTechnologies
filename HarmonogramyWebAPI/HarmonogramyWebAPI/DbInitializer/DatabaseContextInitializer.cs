using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.DbInitializer;

public class DatabaseContextInitializer(IContext context, IConfiguration configuration)
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
        
        await context.SaveChangesAsync();

        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                FirstName = "Test",
                LastName = "Test",
                Email = configuration["AppSettings:FirstSuperuserEmail"]!,
                Password =
                    Security.GetPasswordHash(configuration, configuration["AppSettings:FirstSuperuserPassword"]!),
                IsActive = true,
                IsSuperUser = true,
                IsEmpoyed = true,
                DateOfEmployment = DateOnly.FromDateTime(DateTime.Now),
                CompanyId = context.Companies.FirstOrDefault(x => x.CompanyName == "Test")?.Id,
                EmploymentId = context.Employments.FirstOrDefault(x => x.EmploymentName == "Test")?.Id,
                PositionId = context.Positions.FirstOrDefault(x => x.PositionName == "Test")?.Id
            });
        }

        await context.SaveChangesAsync();
    }
}