using System.ComponentModel.DataAnnotations;

namespace UserAdminUI.Models;

public class UserViewModel
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = "";
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    [Required(ErrorMessage = "Please select at least one group")]
    public List<Guid> GroupIds { get; set; } = new();
    public List<string> GroupNames { get; set; } = new();
    public List<GroupViewModel> Groups { get; set; } = new();


}