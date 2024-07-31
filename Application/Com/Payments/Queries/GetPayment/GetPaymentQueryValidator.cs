using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Payments.Queries.GetPayment;

public class GetPaymentQueryValidator : AbstractValidator<GetPaymentQuery>
{
    public GetPaymentQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("PageNumber must be greater than zero.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("PageSize must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("PageSize cannot exceed 100."); // Adjust the limit as needed
    }
}

