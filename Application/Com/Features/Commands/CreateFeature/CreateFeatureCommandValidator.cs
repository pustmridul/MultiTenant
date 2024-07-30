using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Commands.CreateFeature
{
    internal class CreateFeatureCommandValidator : AbstractValidator<CreateFeatureCommand>
    {
        public CreateFeatureCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                    .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}

