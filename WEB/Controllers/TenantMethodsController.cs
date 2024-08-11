using Application.Com.TenantMethods.Commands.CreateTenantMethod;
using Application.Com.TenantMethods.Commands.DeleteTenantMethod;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using Application.Com.TenantMethods.Queries.GetTenantMethods;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{

    [ApiController]
    public class TenantMethodsController : ApiControllerBase
    {
        public TenantMethodsController()
        {

        }
        [HttpPost]
        public async Task<PaginatedList<TenantDto>> GetAll(GetTenantsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<int> Create(CreateTenantCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut]
        public async Task<IResult> Update(UpdateTenantCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTenantCommand(id));
            return Results.NoContent();
        }
    }
}
