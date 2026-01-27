using Domain.Common;

namespace Domain.Entities;

public class User
{
    private readonly List<Group> _groups = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public IReadOnlyCollection<Group> Groups => _groups;

    private User() { }

    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void SetGroups(IEnumerable<Group> groups)
    {
        _groups.Clear();
        _groups.AddRange(groups);
    }
}