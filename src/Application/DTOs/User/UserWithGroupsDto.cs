namespace Application.DTOs.User;

public class UserWithGroupsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<string> Groups { get; set; } = new();
}