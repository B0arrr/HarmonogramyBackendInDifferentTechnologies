using HarmonogramyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HarmonogramyWebAPI.Interfaces;

public interface IContext: IAsyncDisposable, IDisposable
{
    public DatabaseFacade Database { get; }
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    public DbSet<User> Users { get; }
    public DbSet<Company> Companies { get; }
    public DbSet<Position> Positions { get; }
    public DbSet<Employment> Employments { get; }
    public DbSet<Schedule> Schedules { get; }
    public DbSet<ScheduleUser> ScheduleUsers { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}