using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Permission> Permissions => Set<Permission>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Many-to-many: Users <-> Groups
        modelBuilder.Entity<User>()
            .HasMany(u => u.Groups)
            .WithMany(g => g.Users)
            .UsingEntity(j => j.ToTable("UserGroups"));

        // Seed example data
        modelBuilder.Entity<Group>().HasData(
            new Group { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Admin" },
            new Group { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Level1" }
        );

        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "Read" },
            new Permission { Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), Name = "Write" }
        );
    }
}