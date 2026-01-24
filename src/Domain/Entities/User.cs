using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}