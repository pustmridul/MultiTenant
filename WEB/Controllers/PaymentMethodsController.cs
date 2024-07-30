using Application.Com.PaymentMethods.Commands.CreatePaymentMethod;
using Application.Com.PaymentMethods.Commands.DeletePaymentMethod;
using Application.Com.PaymentMethods.Commands.UpdatePaymentMethod;
using Application.Com.PaymentMethods.Models;
using Application.Com.PaymentMethods.Queries.GetAllPaymentMethod;
using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [ApiController]
    public class PaymentMethodsController : ApiControllerBase
    {
        public PaymentMethodsController()
        {
        }

        [Authorize (Policy = "PaymentMethod.Get")]
        [HttpPost]
        public async Task<PaginatedList<PaymentMethodDto>> GetAll([AsParameters] GetPaymentMethodsQuery query)
        {
            return await Mediator.Send(query);
        }
        [Authorize(Policy = "PaymentMethod.Post")]
        [HttpPost]
        public async Task<int> Create(CreatePaymentMethodCommand command)
        {
            return await Mediator.Send(command);
        }
        [Authorize(Policy = "PaymentMethod.Post")]
        [HttpPost]
        public async Task<IResult> Update(UpdatePaymentMethodCommand command)
        {
            if (command.Id==0) return Results.BadRequest();
           
            await Mediator.Send(command);
            return Results.NoContent();
        }
        [Authorize(Policy = "PaymentMethod.Delete")]
        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeletePaymentMethodCommand(id));
            return Results.NoContent();
        }
    }
}
