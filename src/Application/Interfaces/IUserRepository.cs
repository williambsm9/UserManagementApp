using Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
    void Remove(User user);

    Task<int> CountAsync();
    Task<Dictionary<string, int>> CountPerGroupAsync();

    Task SaveChangesAsync();
}