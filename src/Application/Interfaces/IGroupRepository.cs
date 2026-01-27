using Domain.Entities;

namespace Application.Interfaces;

public interface IGroupRepository
{
    Task<Group?> GetByIdAsync(Guid id);

    Task<List<Group>> GetAllAsync();

    Task AddAsync(Group group);

    Task Remove(Group group);

    Task SaveChangesAsync();
    Task<List<Group>> GetByIdsAsync(IEnumerable<Guid> ids);
}