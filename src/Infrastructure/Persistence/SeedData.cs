using Domain.Entities;

namespace Infrastructure.Persistence;

public static class SeedData
{
    public static readonly Guid AdminGroupId =
        Guid.Parse("11111111-1111-1111-1111-111111111111");

    public static readonly Guid Level1GroupId =
        Guid.Parse("22222222-2222-2222-2222-222222222222");

    public static readonly Guid ReadPermissionId =
        Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

    public static readonly Guid WritePermissionId =
        Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

public static IEnumerable<Group> Groups =>
    new[]
    {
        new Group(AdminGroupId, "Admin"),
        new Group(Level1GroupId, "Level1")
    };

public static IEnumerable<Permission> Permissions =>
    new[]
    {
        new Permission(ReadPermissionId, "Read"),
        new Permission(WritePermissionId, "Write")
    };
}