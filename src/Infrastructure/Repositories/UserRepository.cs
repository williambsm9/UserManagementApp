using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository 
    : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }

    // Override only if behaviour differs
    public override async Task<User?> GetByIdAsync(Guid id)
        => await DbSet
            .Include(u => u.Groups)
            .FirstOrDefaultAsync(u => u.Id == id);

    Task IUserRepository.Remove(User user)
    {
        throw new NotImplementedException();
    }
}