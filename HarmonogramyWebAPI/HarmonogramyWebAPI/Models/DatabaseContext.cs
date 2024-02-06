using HarmonogramyWebAPI.DbInitializer;
using HarmonogramyWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HarmonogramyWebAPI.Models;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options), IContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Company>? Companies { get; set; }
    public DbSet<Position>? Positions { get; set; }
    public DbSet<Employment>? Employments { get; set; }
    public DbSet<Schedule>? Schedules { get; set; }
    public DbSet<ScheduleUser>? ScheduleUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasMany(e => e.Users)
            .WithOne(e => e.Company)
            .HasForeignKey(e => e.CompanyId)
            .IsRequired(false);

        modelBuilder.Entity<Position>()
            .HasMany(e => e.Users)
            .WithOne(e => e.Position)
            .HasForeignKey(e => e.PositionId)
            .IsRequired(false);

        modelBuilder.Entity<Employment>()
            .HasMany(e => e.Users)
            .WithOne(e => e.Employment)
            .HasForeignKey(e => e.EmploymentId)
            .IsRequired(false);

        modelBuilder.Entity<User>()
            .HasMany(e => e.Schedules)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        modelBuilder.Entity<Schedule>()
            .HasMany(e => e.Users)
            .WithOne(e => e.Schedule)
            .HasForeignKey(e => e.ScheduleId)
            .IsRequired();
    }
}