using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<int> 
{
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty; 
    public int TenantId { get; init; }
    public DateTime LastLogin { get; init; }
    public bool IsActive { get; init; }
    public string? ProfilePictureURL { get; init; }
}
internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IAppDbContext _context;
    private readonly IPasswordHash _passwordHash;

    public CreateUserCommandHandler( IAppDbContext context, IPasswordHash passwordHash)
    {
        _context = context;
        _passwordHash = passwordHash;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try {
            var newPassword = new Random(DateTime.UtcNow.Millisecond).Next(1000, 9999);

            string newPasswordHash = string.Empty;
            string newPasswordSaltHash = string.Empty;

            _passwordHash.CreateHash(newPassword.ToString(CultureInfo.InvariantCulture), ref newPasswordHash,
                ref newPasswordSaltHash);

            var entity = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                TenantId = request.TenantId,
                LastLogin = request.LastLogin,
                IsActive = request.IsActive,
                ProfilePictureURL = request.ProfilePictureURL,
                PasswordHash = request.Password,
                PasswordSalt = newPasswordSaltHash,
            };

            if (request.Password.Length == 0)
            {
                entity.Password = newPasswordHash;
                entity.PasswordSalt = newPasswordSaltHash;

            }

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }

        catch (Exception ex) { throw new Exception(ex.Message); }
    }
}