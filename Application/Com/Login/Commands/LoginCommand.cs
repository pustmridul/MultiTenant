using Application.Com.Login.Models;
using System.IdentityModel.Tokens.Jwt;
using static Application.Common.Exceptions.ValidationException;

namespace Application.Com.Login.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; }= string.Empty;
    public string Password { get; set; } = string.Empty;
}
internal class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHash _passwordHash;

    public LoginCommandHandler(IAppDbContext context, ITokenService tokenService, IPasswordHash passwordHash)
    {
        _context = context;
        _tokenService = tokenService;
        _passwordHash = passwordHash;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = new LoginResponse();

            var obj = await _context.Users

                .SingleOrDefaultAsync(q => q.Email == request.Email, cancellationToken);
            if (obj == null) 
            {
                throw new LoginFailedException();
            }
            var isLoginValid = _passwordHash.ValidatePassword(request.Password, obj.PasswordHash, obj.PasswordSalt);
            if (!isLoginValid)
            {
                obj.LoginFailedAttemptCount++;
                obj.LastLoginFailedAttemptDate = DateTime.UtcNow;

                throw new LoginFailedException();
            }
            result.AccessToken = new JwtSecurityTokenHandler().WriteToken(_tokenService.GenerateJWToken(obj));
            result.RefreshToken = _tokenService.GenerateRefreshToken();
            return result;
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }

     
    }
}
