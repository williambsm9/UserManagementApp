using Application.Common.Exceptions;
using Application.DTOs.Group;
using Application.DTOs.User;
using Application.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;

    public UserService(IUserRepository userRepository, IGroupRepository groupRepository)
    {
        _userRepository = userRepository;
        _groupRepository = groupRepository;
    }

    public Task<Guid> CreateUserAsync(CreateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupWithUsersDto>> GetGroupsWithUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalUserCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, int>> GetUserCountPerGroupAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<UserWithGroupsDto>> GetUsersWithGroupsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUserAsync(Guid id, UpdateUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            throw new NotFoundException($"User with id '{id}' not found");

        user.Update(dto.Name, dto.Email);

        if (dto.GroupIds != null && dto.GroupIds.Any())
        {
            var groups = await _groupRepository.GetByIdsAsync(dto.GroupIds);
            user.SetGroups(groups);
        }

        await _userRepository.SaveChangesAsync();
    }
}