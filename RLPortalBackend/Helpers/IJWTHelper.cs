using RLPortalBackend.Entities;

namespace RLPortalBackend.Helpers
{
    /// <summary>
    /// LoginResponseDto Helper
    /// </summary>
    public interface IJWTHelper
    {
        /// <summary>
        /// Create LoginResponseDto
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns>string</returns>
        public string CreateToken(UserEntity user, string role);
    }
}
