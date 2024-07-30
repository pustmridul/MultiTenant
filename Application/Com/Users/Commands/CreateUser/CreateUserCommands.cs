using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<string> // IdentityUser typically uses string as the ID type
{
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty; // You might handle password securely
    public int TenantId { get; init; }
    public DateTime LastLogin { get; init; }
    public bool IsActive { get; init; }
    public string? ProfilePictureURL { get; init; }
}
internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly UserManager<User> _userManager;

    public CreateUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Username, // IdentityUser expects UserName
            Email = request.Email,
            TenantId = request.TenantId,
            LastLogin = request.LastLogin,
            IsActive = request.IsActive,
            ProfilePictureURL = request.ProfilePictureURL
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return user.Id;
        }

        throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
    }
}