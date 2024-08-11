using Application.Com.Invoices.Commands.CreateInvoice;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{

    [ApiController]
    public class InvoicesController : ApiControllerBase
    {
        public InvoicesController()
        {

        }

        [HttpPost]
        public async Task<int> Create(CreateInvoiceCommand command)
        {
            return await Mediator.Send(command);
        }



    }
}
