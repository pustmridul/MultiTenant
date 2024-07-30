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
    private readonly IAppDbContext _context;

    public CreateUserCommandHandler( IAppDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new User
        {
            UserName = request.Username, // IdentityUser expects UserName
            Email = request.Email,
            TenantId = request.TenantId,
            LastLogin = request.LastLogin,
            IsActive = request.IsActive,
            ProfilePictureURL = request.ProfilePictureURL
        };

         _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}