using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Users.Commands.CreateUser
{
    internal class CreateUserCommandsValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandsValidator()
        {
            RuleFor(command => command.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username should not exceed 50 characters.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password should be at least 6 characters long.");

            RuleFor(command => command.TenantId)
                .GreaterThan(0).WithMessage("Tenant ID must be greater than 0.");

            RuleFor(command => command.LastLogin)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Last login date cannot be in the future.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("IsActive field must not be null.");

            RuleFor(command => command.ProfilePictureURL)
                .Must(BeAValidUrl).WithMessage("Invalid URL format for profile picture.");
        }
        private bool BeAValidUrl(string? url)
        {
            if (string.IsNullOrEmpty(url))
                return true; // Assuming URL is optional

            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
