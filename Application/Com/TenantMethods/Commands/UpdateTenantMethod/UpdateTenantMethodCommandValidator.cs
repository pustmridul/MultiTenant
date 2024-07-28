using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.TenantMethods.Commands.UpdateTenantMethod
{
    internal class UpdateTenantMethodCommandValidator : AbstractValidator<UpdateTenantMethodCommand>
    {
        public UpdateTenantMethodCommandValidator()
        {
            RuleFor(v => v.TenantName)
                .MaximumLength(200)
                .NotEmpty();


            RuleFor(v => v.Domain)
                .MaximumLength(100)
                .NotEmpty();


            RuleFor(v => v.SubscriptionPlan)
                .NotEmpty();


            RuleFor(v => v.StorageQuota)
                .GreaterThan(0);


            RuleFor(v => v.PaymentStatusId)
                .GreaterThan(0);


            RuleFor(v => v.BillingAddress)
                .MaximumLength(500)
                .NotEmpty();


            RuleFor(v => v.ContactPerson)
                .MaximumLength(100)
                .NotEmpty();

        }
    }
}
