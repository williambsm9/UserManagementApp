using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GroupRepository 
    : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(AppDbContext context)
        : base(context)
    {
    }

    public override async Task<Group?> GetByIdAsync(Guid id)
        => await DbSet
            .Include(g => g.Users)
            .FirstOrDefaultAsync(g => g.Id == id);

    public async Task<List<Group>> GetGroupsWithUsersAsync()
        => await DbSet
            .Include(g => g.Users)
            .ToListAsync();

    Task IGroupRepository.Remove(Group group)
    {
        throw new NotImplementedException();
    }
    public async Task<List<Group>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await DbSet
            .Where(g => ids.Contains(g.Id))
            .ToListAsync();
    }
}