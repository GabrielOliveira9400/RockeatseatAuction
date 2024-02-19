using Microsoft.AspNetCore.Mvc;
using RockeatseatAuction.API.Entities;
using RockeatseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RockeatseatAuction.API.Controllers;

    public class AuctionController : RocketseatAuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
        {
            
            var result = useCase.Execute();

            if (result is null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }