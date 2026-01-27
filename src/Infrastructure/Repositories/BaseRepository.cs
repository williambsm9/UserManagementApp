using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        => await DbSet.FindAsync(id);

    public virtual async Task<List<TEntity>> GetAllAsync()
        => await DbSet.ToListAsync();

    public virtual async Task AddAsync(TEntity entity)
        => await DbSet.AddAsync(entity);

    public virtual void Remove(TEntity entity)
        => DbSet.Remove(entity);

    public virtual async Task SaveChangesAsync()
        => await Context.SaveChangesAsync();
}