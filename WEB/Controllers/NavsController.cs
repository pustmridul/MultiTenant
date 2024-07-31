using Application.Com.Navs.Commands.CreateNav;
using Application.Com.Navs.Commands.DeleteNav;
using Application.Com.Navs.Commands.UpdateNav;
using Application.Com.Navs.Queries.GetAllNav;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [ApiController]
    public class NavsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await Mediator.Send(new GetNavsQuery()));
        }
        [HttpPost]
        public async Task<int> Create(CreateNavCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost]
        public async Task<IResult> Update(UpdateNavCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.NoContent();
        }
        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeleteNavCommand(id));
            return Results.NoContent();
        }
    }
}
