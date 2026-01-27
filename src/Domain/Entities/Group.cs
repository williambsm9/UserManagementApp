using Domain.Common;

namespace Domain.Entities;

public class Group
{
    private readonly List<Permission> _permissions = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;

    public List<User> Users { get; private set; } = new();
    public IReadOnlyCollection<Permission> Permissions => _permissions;

    private Group() { }

    public Group(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}