using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Prices.Commands.CreatePrice;

    internal class CreatePriceCommandValidator : AbstractValidator<CreatePriceCommand>
    {
        public CreatePriceCommandValidator()
        {
            RuleFor(x => x.PlanId)
                .GreaterThan(0).WithMessage("PlanId must be greater than 0.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
