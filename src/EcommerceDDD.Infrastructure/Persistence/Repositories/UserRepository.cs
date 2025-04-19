using EcommerceDDD.Domain.Entities.Users;
using EcommerceDDD.Infrastructure.Persistence;

namespace EcommerceDDD.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
} 