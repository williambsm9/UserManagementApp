using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateUserAsync(string name, string email)
    {
        var user = new Domain.Entities.User
        {
            Name = name,
            Email = email
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task UpdateUserAsync(Guid id, string name, string email)
    {
        var user = await _context.Users.FindAsync(id)
            ?? throw new KeyNotFoundException("User not found");

        user.Name = name;
        user.Email = email;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id)
            ?? throw new KeyNotFoundException("User not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetTotalUserCountAsync()
    {
        return await _context.Users.CountAsync();
    }

    public async Task<Dictionary<string, int>> GetUserCountPerGroupAsync()
    {
        return await _context.Groups
            .Select(g => new
            {
                g.Name,
                Count = g.Users.Count
            })
            .ToDictionaryAsync(x => x.Name, x => x.Count);
    }
}