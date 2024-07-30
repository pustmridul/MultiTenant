using Application.Com.Invoices.Commands.CreateInvoice;
using Application.Com.TenantMethods.Commands.CreateTenantMethod;
using Application.Com.TenantMethods.Commands.DeleteTenantMethod;
using Application.Com.TenantMethods.Commands.UpdateTenantMethod;
using Application.Com.TenantMethods.Models;
using Application.Com.TenantMethods.Queries.GetTenantMethods;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
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
