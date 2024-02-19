using Microsoft.EntityFrameworkCore;
using RockeatseatAuction.API.Entities;
using RockeatseatAuction.API.Interfaces;
using RockeatseatAuction.API.Repositories;

namespace RockeatseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _auctionRepository;
    
    public GetCurrentAuctionUseCase(IAuctionRepository auctionRepository) => _auctionRepository = auctionRepository;
    public Auction? Execute() => _auctionRepository.GetCurrent();
    
}