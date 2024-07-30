using Application.Com.Login.Models;

namespace Application.Com.Login.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Username { get; set; }= string.Empty;
    public string Password { get; set; } = string.Empty;
}
internal class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAppDbContext _context;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IAppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = new LoginResponse();
            return result;
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }

     
    }
}
