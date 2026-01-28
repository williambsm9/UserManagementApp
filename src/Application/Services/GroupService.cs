using Application.DTOs.Group;
using Application.Interfaces;

namespace Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<List<GroupWithUsersDto>> GetGroupsWithUsersAsync()
    {
        var groups = await _groupRepository.GetAllWithUsersAsync();

        return groups.Select(g => new GroupWithUsersDto
        {
            Id = g.Id,
            Name = g.Name,
            Users = g.Users.Select(u => u.Name).ToList()
        }).ToList();
    }

    public async Task<List<GroupDto>> GetAllAsync()
    {
        var groups = await _groupRepository.GetAllAsync();

        return groups.Select(g => new GroupDto
        {
            Id = g.Id,
            Name = g.Name
        }).ToList();
    }

}