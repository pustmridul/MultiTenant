using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Features.Queries.GetFeature;

internal class GetFeatureQueryValidator:AbstractValidator<GetFeatureQuery>
{
    public GetFeatureQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Page number must be greater than zero.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Page size must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("Page size must be 100 or less."); // Optional: adjust limit as needed
    }
}
