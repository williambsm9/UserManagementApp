using Domain.Common;

namespace Domain.Entities;

public class Permission : BaseEntity
{
    public string Name { get; set; } = null!;
}