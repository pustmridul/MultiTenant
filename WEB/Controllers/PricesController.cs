using Application.Com.Features.Commands.CreateFeature;
using Application.Com.Features.Commands.DeleteFeature;
using Application.Com.Features.Commands.UpdateFeature;
using Application.Com.Features.Models;
using Application.Com.Features.Queries.GetFeature;
using Application.Com.Prices.Commands.CreatePrice;
using Application.Com.Prices.Commands.UpdatePrice;
using Application.Com.Prices.Models;
using Application.Com.Prices.Queries.GetPrice;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
   
    [ApiController]
    public class PricesController :ApiControllerBase
    {

        public PricesController()
        {
            
        }
        [HttpGet]
        public async Task<PaginatedList<PricingDto>> GetAll([FromQuery] GetPriceQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpPost]
        public async Task<int> Create([AsParameters] CreatePriceCommand query)
        {
            return await Mediator.Send(query);
        }
        [HttpPut]
        public async Task<IResult> Update(UpdatePriceCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.Ok();
        }

        //[HttpDelete]
        //public async Task<IResult> Delete(int id)
        //{
        //    await Mediator.Send(new DeletePriceCommand(id));
        //    return Results.NoContent();
        //}
    }
}
