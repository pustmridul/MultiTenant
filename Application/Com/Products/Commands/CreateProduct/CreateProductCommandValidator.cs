using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Products.Commands.CreateProduct;

internal class CreateProductsCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductsCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(command => command.Description)
            .MaximumLength(500).WithMessage("Description should not exceed 500 characters.");

        RuleFor(command => command.PricingModel)
            .MaximumLength(50).WithMessage("Pricing model should not exceed 50 characters.");

        RuleFor(command => command.IsActive)
            .NotNull().WithMessage("IsActive field must not be null.");

        RuleFor(command => command.ReleaseDate)
            .GreaterThan(DateTime.Now).WithMessage("Release date must be in the future.");

        RuleFor(command => command.EndofLifeDate)
            .GreaterThan(command => command.ReleaseDate).WithMessage("End of life date must be after the release date.");
    }
}