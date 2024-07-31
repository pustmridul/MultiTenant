using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Roles.Commands.UpdateRole;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Role ID must be greater than zero.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role name cannot be empty.")
            .MaximumLength(100).WithMessage("Role name cannot exceed 100 characters.");
    }
}
