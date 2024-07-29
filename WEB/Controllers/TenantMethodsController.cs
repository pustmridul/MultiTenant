using Application.Com.PaymentMethods.Commands.CreatePaymentMethod;
using Application.Com.PaymentMethods.Commands.DeletePaymentMethod;
using Application.Com.PaymentMethods.Commands.UpdatePaymentMethod;
using Application.Com.PaymentMethods.Models;
using Application.Com.PaymentMethods.Queries.GetAllPaymentMethod;
using Application.Com.TenantMethods.Commands.CreateTenantMethod;
using Application.Com.TenantMethods.Commands.DeleteTenantMethod;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using Application.Com.TenantMethods.Queries.GetTenantMethods;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<PaginatedList<TenantDto>> GetAll( GetTenantMethodsQuerie query)
        {
            return await Mediator.Send(query);
        }
       
        [HttpPost]
        public async Task<int> Create(CreateTenantMethodCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut]
        public async Task<IResult> Update(UpdateTenantMethodCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTenantMethodCommand(id));
            return Results.NoContent();
        }
    }
}
