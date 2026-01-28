using Application.DTOs.Group;

public interface IGroupService
{
    Task<List<GroupWithUsersDto>> GetGroupsWithUsersAsync();
    Task<List<GroupDto>> GetAllAsync();
}