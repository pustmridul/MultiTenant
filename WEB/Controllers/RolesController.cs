using Application.Com.TenantMethods.Commands.CreateTenantMethod;
using Application.Com.TenantMethods.Commands.DeleteTenantMethod;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using Application.Com.TenantMethods.Queries.GetTenantMethods;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Com.Roles.Models;
using Application.Com.Roles.Queries.GetRole;
using Application.Com.Roles.Commands.CreateRole;
using Application.Com.Roles.Commands.UpdateRole;
using Application.Com.Roles.Commands.DeleteRole;

namespace WEB.Controllers
{
    
    [ApiController]
    public class RolesController : ApiControllerBase
    {

       public RolesController() { }
        [HttpPost]
        public async Task<PaginatedList<RoleDto>> GetAll(GetRoleQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<int> Create(CreateRoleCommand command)
        {
            return await Mediator.Send(command);
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
