using Microsoft.IdentityModel.Tokens;
using RLPortalBackend.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RLPortalBackend.Helpers.Impl
{
    /// <summary>
    /// LoginResponseDto Helper
    /// </summary>
    public class JWTHelper : IJWTHelper
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// JWTHelper constructor
        /// </summary>
        /// <param name="configuration"></param>
        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create LoginResponseDto
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns>string</returns>
        public string CreateToken(UserEntity user, string role)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, user.Id)


            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddDays(1));

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
