using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Navs.Commands.UpdateNav;

public class UpdateNavCommandValidator : AbstractValidator<UpdateNavCommand>
{
    public UpdateNavCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}
