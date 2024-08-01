using Application.Com.Features.Commands.CreateFeature;
using Application.Com.Features.Commands.DeleteFeature;
using Application.Com.Features.Commands.UpdateFeature;
using Application.Com.Features.Models;
using Application.Com.Features.Queries.GetFeature;
using Application.Com.Plans.Models;
using Application.Com.Plans.Queries.GetPlan;
using Application.Com.TenantMethods.Commands.DeleteTenantMethod;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.Users.Commands.CreateUser;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
   
    [ApiController]
    public class FeaturesController : ApiControllerBase
    {
        public FeaturesController()
        {
        }

        [HttpGet]
        public async Task<PaginatedList<FeaturesDto>> GetAll([FromQuery] GetFeatureQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpPost]
        public async Task<int> Create([AsParameters] CreateFeatureCommand query)
        {
            return await Mediator.Send(query);
        }
        [HttpPut]
        public async Task<IResult> Update(UpdateFeatureCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeleteFeatureCommand(id));
            return Results.NoContent();
        }
    }
}
