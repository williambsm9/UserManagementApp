namespace Application.Interfaces;

public interface IUserService
{
    Task<Guid> CreateUserAsync(string name, string email);
    Task UpdateUserAsync(Guid id, string name, string email);
    Task DeleteUserAsync(Guid id);

    Task<int> GetTotalUserCountAsync();
    Task<Dictionary<string, int>> GetUserCountPerGroupAsync();
}