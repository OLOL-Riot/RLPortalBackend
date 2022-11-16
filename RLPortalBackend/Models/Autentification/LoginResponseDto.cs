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
        /// LoginResponseDto constructor
        /// </summary>
        /// <param name="token"></param>
        public LoginResponseDto (string token)
        {
            Token = token;
        }
    }
}
