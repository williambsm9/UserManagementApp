using Domain.Common;

namespace Domain.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}