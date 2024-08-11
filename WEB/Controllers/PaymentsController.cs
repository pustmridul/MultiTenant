using Application.Com.Payments.Commands.CreatePayment;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{

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
