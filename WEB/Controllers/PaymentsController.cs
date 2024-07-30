using Application.Com.Invoices.Commands.CreateInvoice;
using Application.Com.Payments.Commands.CreatePayment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ApiControllerBase
    {
        public PaymentsController()
        {

        }

        [HttpPost]
        public async Task<int> Create(CreatePaymentCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
