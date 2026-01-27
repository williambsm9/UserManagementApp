using Domain.Common;

namespace Domain.Entities;

public class Permission
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;

    private Permission() { }

    public Permission(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}