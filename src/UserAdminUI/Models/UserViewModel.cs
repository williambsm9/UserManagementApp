using System.ComponentModel.DataAnnotations;

namespace UserAdminUI.Models;

public class UserViewModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public List<Guid> GroupIds { get; set; } = new List<Guid>();
    public List<string> GroupNames { get; set; } = new List<string>();
}