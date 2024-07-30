using Application.Com.Features.Commands.CreateFeature;
using Application.Com.Features.Commands.DeleteFeature;
using Application.Com.Features.Commands.UpdateFeature;
using Application.Com.TenantMethods.Commands.DeleteTenantMethod;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
   
    [ApiController]
    public class FeatureController : ApiControllerBase
    {
        public FeatureController() 
        { 
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
