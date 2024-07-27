using Domain.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WEB.Services;

public interface ITokenService
{
    JwtSecurityToken GenerateJWToken(User user, string ipAddress, int warehouseId);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}