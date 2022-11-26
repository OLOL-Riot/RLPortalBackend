using RLPortalBackend.Entities;
using System.Security.Claims;

namespace RLPortalBackend.Helpers
{
    /// <summary>
    /// LoginResponseDto Helper
    /// </summary>
    public interface ITokenHelper
    {
        /// <summary>
        /// Create LoginResponseDto
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns>string</returns>
        public string CreateToken(UserEntity user, string role);
        public string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
