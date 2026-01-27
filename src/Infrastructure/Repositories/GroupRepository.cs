using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Group?> GetByIdAsync(Guid id)
        => await _context.Groups.FindAsync(id);

    public async Task<List<Group>> GetAllAsync()
        => await _context.Groups.ToListAsync();

    public async Task<List<Group>> GetAllWithUsersAsync()
        => await _context.Groups
            .Include(g => g.Users)
            .ToListAsync();

    public async Task<List<Group>> GetByIdsAsync(IEnumerable<Guid> ids)
        => await _context.Groups
            .Where(g => ids.Contains(g.Id))
            .ToListAsync();

    public async Task AddAsync(Group group)
        => await _context.Groups.AddAsync(group);

    public Task Remove(Group group)
    {
        _context.Groups.Remove(group);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}