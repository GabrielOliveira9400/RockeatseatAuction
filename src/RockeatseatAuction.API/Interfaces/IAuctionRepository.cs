using RockeatseatAuction.API.Entities;

namespace RockeatseatAuction.API.Interfaces;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}