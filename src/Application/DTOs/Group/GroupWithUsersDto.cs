namespace Application.DTOs.Group;

public class GroupWithUsersDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<string> Users { get; set; } = new();
}