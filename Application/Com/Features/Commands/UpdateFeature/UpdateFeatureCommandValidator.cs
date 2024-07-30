using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Commands.UpdateFeature;

internal class UpdateFeatureCommandValidator: AbstractValidator<UpdateFeatureCommand>
{
    public UpdateFeatureCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Feature ID must be greater than zero.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}
