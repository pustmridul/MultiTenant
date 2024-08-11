using Application.Com.Roles.Commands.CreateRole;
using Application.Com.Roles.Commands.DeleteRole;
using Application.Com.Roles.Commands.UpdateRole;
using Application.Com.Roles.Queries.GetRole;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{

    [ApiController]
    public class RolesController : ApiControllerBase
    {
        public RolesController() { }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetRolesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut]
        public async Task<IResult> Update(UpdateRoleCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRoleCommand(id));
            return Results.NoContent();
        }
    }
}
