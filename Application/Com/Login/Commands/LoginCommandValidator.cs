using Application.Com.PaymentMethods.Commands.CreatePaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Login.Commands;

internal class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(v => v.Email)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Password)
            .MaximumLength(200)
            .NotEmpty();
    }
}
