using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
        => await _context.Users.AddAsync(user);

    public async Task<User?> GetByIdAsync(Guid id)
        => await _context.Users
            .Include(u => u.Groups)
            .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<List<User>> GetAllAsync()
        => await _context.Users
            .Include(u => u.Groups)
            .ToListAsync();

    public void Remove(User user)
        => _context.Users.Remove(user);

    public async Task<int> CountAsync()
        => await _context.Users.CountAsync();

    public async Task<Dictionary<string, int>> CountPerGroupAsync()
    {
        return await _context.Groups
            .Select(g => new { g.Name, Count = g.Users.Count })
            .ToDictionaryAsync(x => x.Name, x => x.Count);
    }

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}