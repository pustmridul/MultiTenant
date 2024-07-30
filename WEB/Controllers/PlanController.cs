using Application.Com.Features.Commands.DeleteFeature;
using Application.Com.Features.Commands.UpdateFeature;
using Application.Com.Plans.Commands.CreatePlan;
using Application.Com.Plans.Commands.DeletePlan;
using Application.Com.Plans.Commands.UpdatePlan;
using Application.Com.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    
    [ApiController]
    public class PlanController : ApiControllerBase
    {
        [HttpPost]
        public async Task<int> Create([AsParameters] CreatePlanCommand query)
        {
            return await Mediator.Send(query);
        }
        public async Task<IResult> Update(UpdatePlanCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeletePlanCommand(id));
            return Results.NoContent();
        }
    }
}
