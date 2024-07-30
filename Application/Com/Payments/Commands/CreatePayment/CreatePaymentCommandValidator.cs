using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Payments.Commands.CreatePayment
{
    internal class CreatePaymentCommandValidator: AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(v => v.SubscriptionId)
                .GreaterThan(0).WithMessage("SubscriptionId must be greater than zero.");

            RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(v => v.PaymentDate)
                .NotEmpty().WithMessage("PaymentDate is required.");

            RuleFor(v => v.PaymentMethodId)
                .GreaterThan(0).WithMessage("PaymentMethodId must be greater than zero.");

            RuleFor(v => v.PaymentStatusId)
                .GreaterThan(0).WithMessage("PaymentStatusId must be greater than zero.");

            RuleFor(v => v.InvoiceId)
                .GreaterThan(0).WithMessage("InvoiceId must be greater than zero.");
        }
    }
}
