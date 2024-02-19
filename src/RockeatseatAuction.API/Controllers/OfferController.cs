using Microsoft.AspNetCore.Mvc;
using RockeatseatAuction.API.Communication.Requests;
using RockeatseatAuction.API.Filters;
using RockeatseatAuction.API.UseCases.Offers.CreateOffer;


namespace RockeatseatAuction.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : RocketseatAuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateOffer([FromRoute]int itemId, [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
        {
            int id = useCase.Execute(itemId, request); 
            return Created(String.Empty, id);
        }
    }
}
