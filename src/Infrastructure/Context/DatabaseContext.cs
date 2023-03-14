using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Identity;
using Infrastructure.Configuration;
using Infrastructure.Shared.Abstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DatabaseContext : IdentityDbContext<User, Role, Guid>
{
    private readonly ICurrentDateProvider _currentDateProvider;

    public DatabaseContext()
    {
        
    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options,ICurrentDateProvider currentDateProvider) : base(options)
    {
        _currentDateProvider = currentDateProvider;
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
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Seeds

        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new ForumConfiguration());

        #endregion

        builder.Entity<ForumList>(entity =>
        {
            entity.Property(e => e.Title).IsRequired();
        });

        builder.Entity<BookMark>(entity =>
        {
            entity.Property(e => e.UserId).IsRequired();
        });
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AddModelTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddModelTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        //get current user
        var currentUser = Guid.NewGuid();
        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedOn = _currentDateProvider.NowUtc;
                ((BaseEntity)entity.Entity).CreatedBy = currentUser;
            }
            //modification
            ((BaseEntity)entity.Entity).LastModifiedOn = _currentDateProvider.NowUtc;
            ((BaseEntity)entity.Entity).LastModifiedBy = currentUser;
        }
    }

}