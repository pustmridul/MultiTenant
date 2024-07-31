using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Navs.Commands.CreateNav
{
    public class CreateNavCommandValidator : AbstractValidator<CreateNavCommand>
    {
        public CreateNavCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
