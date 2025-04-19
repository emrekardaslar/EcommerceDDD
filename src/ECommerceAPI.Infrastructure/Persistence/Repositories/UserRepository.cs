using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Infrastructure.Persistence;

namespace ECommerceAPI.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
} 