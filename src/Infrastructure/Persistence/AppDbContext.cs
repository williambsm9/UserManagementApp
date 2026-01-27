using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Permission> Permissions => Set<Permission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Groups)
            .WithMany(g => g.Users);

        modelBuilder.Entity<Group>()
            .HasMany(g => g.Permissions)
            .WithMany();

        modelBuilder.Entity<Group>().HasData(SeedData.Groups);
        modelBuilder.Entity<Permission>().HasData(SeedData.Permissions);

    }
}