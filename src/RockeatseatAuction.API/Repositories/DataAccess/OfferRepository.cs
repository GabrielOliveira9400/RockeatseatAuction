using RockeatseatAuction.API.Entities;
using RockeatseatAuction.API.Interfaces;

namespace RockeatseatAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;
    
    public OfferRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;
    
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}