using Microsoft.EntityFrameworkCore;
using RockeatseatAuction.API.Entities;
using RockeatseatAuction.API.Interfaces;

namespace RockeatseatAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;
    
    public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = new DateTime(2024,05, 01);
        
        return _dbContext.Auctions
            .Include(x => x.Items)
            .FirstOrDefault(x => today >= x.Starts && today <= x.Ends);
    }

}