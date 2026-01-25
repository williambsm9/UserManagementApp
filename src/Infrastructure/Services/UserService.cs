using Application.DTOs.Group;
using Application.DTOs.User;
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

    public async Task<Guid> CreateUserAsync(CreateUserDto dto)
    {
        var groups = await _context.Groups
            .Where(g => dto.GroupIds.Contains(g.Id))
            .ToListAsync();

        var user = new Domain.Entities.User
        {
            Name = dto.Name,
            Email = dto.Email,
            Groups = groups
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task UpdateUserAsync(Guid id, UpdateUserDto dto)
    {
        var user = await _context.Users
            .Include(u => u.Groups)
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new KeyNotFoundException("User not found");

        user.Name = dto.Name;
        user.Email = dto.Email;

        user.Groups.Clear();

        var groups = await _context.Groups
            .Where(g => dto.GroupIds.Contains(g.Id))
            .ToListAsync();

        foreach (var group in groups)
        {
            user.Groups.Add(group);
        }

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
        => await _context.Users.CountAsync();

    public async Task<Dictionary<string, int>> GetUserCountPerGroupAsync()
    {
        return await _context.Groups
            .Select(g => new { g.Name, Count = g.Users.Count })
            .ToDictionaryAsync(x => x.Name, x => x.Count);
    }

    public async Task<List<UserWithGroupsDto>> GetUsersWithGroupsAsync()
    {
        return await _context.Users
            .Include(u => u.Groups)
            .Select(u => new UserWithGroupsDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Groups = u.Groups.Select(g => g.Name).ToList()
            })
            .ToListAsync();
    }

    public async Task<List<GroupWithUsersDto>> GetGroupsWithUsersAsync()
    {
        return await _context.Groups
            .Include(g => g.Users)
            .Select(g => new GroupWithUsersDto
            {
                Id = g.Id,
                Name = g.Name,
                Users = g.Users.Select(u => u.Name).ToList()
            })
            .ToListAsync();
    }
}