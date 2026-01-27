using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User;

public class CreateUserDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public List<Guid> GroupIds { get; set; } = new();
}