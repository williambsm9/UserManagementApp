using Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);

    Task Remove(User user);

    Task SaveChangesAsync();
}