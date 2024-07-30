using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using Application.Com.PaymentMethods.Commands.CreatePaymentMethod;

namespace Application.Com.Invoices.Commands.CreateInvoice;

internal class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(v => v.SubscriptionId)
            .GreaterThan(0).WithMessage("SubscriptionId must be greater than zero.");

        RuleFor(v => v.DueDate)
            .NotEmpty().WithMessage("DueDate is required.");

        RuleFor(v => v.AmountDue)
            .GreaterThan(0).WithMessage("AmountDue must be greater than zero.");

        RuleFor(v => v.IssuedDate)
            .GreaterThanOrEqualTo(v => v.DueDate)
            .When(v => v.IssuedDate.HasValue)
            .WithMessage("IssuedDate cannot be earlier than DueDate.");

        RuleFor(v => v.InvoiceStatusId)
            .GreaterThan(0).WithMessage("InvoiceStatusId must be greater than zero.");
    }
}
