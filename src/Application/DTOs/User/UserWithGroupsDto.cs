using System.Text.RegularExpressions;
using Application.DTOs.Group;

namespace Application.DTOs.User;

public class UserWithGroupsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<GroupDto> Groups { get; set; } = new();
}