using RockeatseatAuction.API.Entities;

namespace RockeatseatAuction.API.Interfaces;

public interface IUserRepository
{
    public bool ExistUserWithEmail(string email);
    public User GetByEmail(string email);
}