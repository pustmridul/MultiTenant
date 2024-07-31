using Application.Com.PaymentMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Payments.Models;

public class PaymentDto
{
    public int Id { get; init; }
    public int SubscriptionId { get; init; }
    public decimal Amount { get; init; }
    public DateTime PaymentDate { get; init; }
    public int PaymentMethodId { get; init; }
    public int PaymentStatusId { get; init; }
    public int InvoiceId { get; init; }
    private class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
            CreateMap<Payment, PaymentDto>();
        }
    }
}
