using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Plans.Queries.GetPlan;

internal class GetPlanQueryValidator: AbstractValidator<GetPlanQuery>
{
    public GetPlanQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("PageNumber must be greater than zero.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("PageSize must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("PageSize cannot exceed 100."); // You can adjust this limit as needed
    }
}
