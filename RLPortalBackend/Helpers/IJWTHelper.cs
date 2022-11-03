using RLPortalBackend.Entities;

namespace RLPortalBackend.Helpers
{
    /// <summary>
    /// JWT Helper
    /// </summary>
    public interface IJWTHelper
    {
        /// <summary>
        /// Create JWT
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns>string</returns>
        public string CreateToken(User user, string role);
    }
}
