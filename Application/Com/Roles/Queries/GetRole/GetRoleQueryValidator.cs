﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Queries.GetRole;

public class GetRoleQueryValidator : AbstractValidator<GetRolesQuery>
{
    public GetRoleQueryValidator()
    {
        //RuleFor(x => x.PageNumber)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        //RuleFor(x => x.PageSize)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
