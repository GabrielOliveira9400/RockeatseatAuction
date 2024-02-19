using RockeatseatAuction.API.Entities;
using RockeatseatAuction.API.Interfaces;

namespace RockeatseatAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public UserRepository(RocketseatAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(u => u.Email == email);
    }
    
    public User GetByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }
}