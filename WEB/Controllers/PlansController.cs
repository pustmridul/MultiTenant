using Application.Com.Plans.Commands.CreatePlan;
using Application.Com.Plans.Commands.DeletePlan;
using Application.Com.Plans.Commands.UpdatePlan;
using Application.Com.Plans.Models;
using Application.Com.Plans.Queries.GetPlan;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    
    [ApiController]
    public class PlansController : ApiControllerBase
    {

        public PlansController()
        { 
        }
        
        [HttpGet]
        public async Task<PaginatedList<PlanDto>> GetAll([FromQuery] GetPlanQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlanCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
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
