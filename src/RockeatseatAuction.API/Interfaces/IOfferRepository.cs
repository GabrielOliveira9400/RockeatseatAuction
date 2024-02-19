using RockeatseatAuction.API.Entities;

namespace RockeatseatAuction.API.Interfaces;

public interface IOfferRepository
{
    void Add(Offer offer);
}