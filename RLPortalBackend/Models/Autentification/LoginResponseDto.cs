namespace RLPortalBackend.Models
{
    /// <summary>
    /// LoginResponseDto class
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string RefreshToken { get; set; }

    }
}
