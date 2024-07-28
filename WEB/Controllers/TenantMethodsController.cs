using Application.Com.PaymentMethods.Commands.CreatePaymentMethod;
using Application.Com.TenantMethods.Commands.CreateTenantMethod;
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
    }
}
