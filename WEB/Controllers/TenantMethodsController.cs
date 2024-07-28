using Application.Com.PaymentMethods.Commands.CreatePaymentMethod;
using Application.Com.PaymentMethods.Commands.DeletePaymentMethod;
using Application.Com.PaymentMethods.Commands.UpdatePaymentMethod;
using Application.Com.TenantMethods.Commands.CreateTenantMethod;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
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
        public async Task<int> Create(CreateTenantMethodCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost]
        public async Task<IResult> Update(UpdateTenantMethodCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.NoContent();
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeletePaymentMethodCommand(id));
            return Results.NoContent();
        }
    }
}
