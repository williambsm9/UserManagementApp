using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User;

public class UpdateUserDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public List<Guid> GroupIds { get; set; } = new();
}