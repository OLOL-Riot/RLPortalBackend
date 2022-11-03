namespace RLPortalBackend.Models
{
    /// <summary>
    /// JWT class
    /// </summary>
    public class JWT
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// JWT constructor
        /// </summary>
        /// <param name="token"></param>
        public JWT (string token)
        {
            Token = token;
        }
    }
}
