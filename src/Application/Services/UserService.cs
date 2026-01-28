using Application.Common.Exceptions;
using Application.DTOs.User;
using Application.DTOs.Group;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _users;
    private readonly IGroupRepository _groups;

    public UserService(IUserRepository users, IGroupRepository groups)
    {
        _users = users;
        _groups = groups;
    }

    public async Task<Guid> CreateUserAsync(CreateUserDto dto)
    {
        var user = new User(dto.Name, dto.Email);

        if (dto.GroupIds.Any())
        {
            var groups = await _groups.GetByIdsAsync(dto.GroupIds);
            user.SetGroups(groups);
        }

        await _users.AddAsync(user);
        await _users.SaveChangesAsync();

        return user.Id;
    }

    public async Task UpdateUserAsync(Guid id, UpdateUserDto dto)
    {
        var user = await _users.GetByIdAsync(id);

        if (user is null)
        {
            throw new NotFoundException($"User with id '{id}' not found");
        }

        user.Update(dto.Name, dto.Email);

        var groups = await _groups.GetByIdsAsync(dto.GroupIds);
        user.SetGroups(groups);

        await _users.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _users.GetByIdAsync(id)
            ?? throw new NotFoundException("User not found");

        _users.Remove(user);
        await _users.SaveChangesAsync();
    }

    public Task<int> GetTotalUserCountAsync()
        => _users.CountAsync();

    public async Task<List<UserWithGroupsDto>> GetAllAsync()
    {
        var users = await _users.GetAllAsync();


        return users.Select(u => new UserWithGroupsDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Groups = u.Groups.Select(g => new GroupDto { Id = g.Id, Name = g.Name }).ToList()
        }).ToList();
    }

    public async Task<UserWithGroupsDto> GetByIdAsync(Guid id)
    {
        var user = await _users.GetByIdAsync(id)
            ?? throw new NotFoundException("User not found");


        return new UserWithGroupsDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Groups = user.Groups.Select(g => new GroupDto { Id = g.Id, Name = g.Name }).ToList()
        };
    }

    public Task<Dictionary<string, int>> GetUserCountPerGroupAsync()
        => _users.CountPerGroupAsync();
}