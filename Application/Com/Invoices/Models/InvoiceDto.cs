using Application.Com.PaymentMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Invoices.Models
{
    public class InvoiceDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }

        private class InvoiceMapping : Profile
        {
            public InvoiceMapping()
            {
                CreateMap<Invoice, InvoiceDto>();
            }
        }
    }
}
