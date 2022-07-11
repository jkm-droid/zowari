using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Shared.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Context;

public class DatabaseContext : DbContext
{
    private readonly ICurrentDateProvider _currentDateProvider;

    public DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options,ICurrentDateProvider currentDateProvider) : base(options)
    {
        _currentDateProvider = currentDateProvider;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    public DbSet<ForumList> ForumLists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<BookMark> BookMarks { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Activity> Activities { get; set; }
    
    private IEnumerable<IBaseEntity> FilterTrackedEntriesByState(EntityState entityState)
    {
        return ChangeTracker
            .Entries()
            .Where(e => e.Entity is IBaseEntity && e.State == entityState)
            .Select(e => (IBaseEntity)e.Entity);
    }
}