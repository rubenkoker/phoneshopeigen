using PhoneShop.Shared.Auth;
using System.Security.Claims;

namespace PhoneShop.Contracts.Interfaces
{
    /// <summary>
    /// Defines the interface for the JWTAuthManager, used to generate JWT Tokens
    /// </summary>
    public interface IJwtAuthManager
    {
        /// <summary>
        /// Method used to generate a JWT Token
        /// </summary>
        /// <returns>A refresh token and an access token</returns>
        JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
    }
}