namespace Users.Application.DTOs.Users;

public class UserResponseDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}