using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    private readonly List<Group> _groups = new();

    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();

    private User() { } // For EF

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    /// <summary>
    /// Domain-controlled update
    /// </summary>
    public void Update(string name, string email, IEnumerable<Guid>? groupIds = null)
    {
        Name = name;
        Email = email;

        // Group updates are handled at service level
        // This method intentionally does NOT touch navigation collections
    }

    /// <summary>
    /// Explicit domain behavior for groups
    /// </summary>
    public void SetGroups(IEnumerable<Group> groups)
    {
        _groups.Clear();
        _groups.AddRange(groups);
    }
}