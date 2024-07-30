using Application.Com.UserLogs.Commands.CreateUserLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.UserLogs.Commands.CreateUsageLog;

internal class CreateUserLogCommandsValidator : AbstractValidator<CreateUserLogCommands>

{
    public CreateUserLogCommandsValidator()
    {
        RuleFor(v => v.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than zero.");

        RuleFor(v => v.Action)
            .NotEmpty().WithMessage("Action is required.")
            .MaximumLength(100).WithMessage("Action must not exceed 100 characters.");

        RuleFor(v => v.DeviceInfo)
            .MaximumLength(200).WithMessage("DeviceInfo must not exceed 200 characters.");

        RuleFor(v => v.IpAddress)
            .MaximumLength(45).WithMessage("IpAddress must not exceed 45 characters.") // IPv6 addresses can be up to 45 characters long
            .Matches(@"^((25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9]?)$|^([0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$")
            .WithMessage("IpAddress is not a valid IP address.");
    }
}
