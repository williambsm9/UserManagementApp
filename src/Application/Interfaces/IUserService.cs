using Application.DTOs.Group;
using Application.DTOs.User;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Guid> CreateUserAsync(CreateUserDto dto);
    Task UpdateUserAsync(Guid id, UpdateUserDto dto);
    Task<List<UserWithGroupsDto>> GetAllAsync();
    Task DeleteUserAsync(Guid id);
    Task<int> GetTotalUserCountAsync();
    Task<Dictionary<string, int>> GetUserCountPerGroupAsync();
}