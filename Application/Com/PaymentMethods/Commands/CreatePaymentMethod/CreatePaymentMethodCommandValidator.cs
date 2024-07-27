using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.PaymentMethods.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodCommandValidator : AbstractValidator<CreatePaymentMethodCommand>
    {
        public CreatePaymentMethodCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
