﻿namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// Auth data
    /// </summary>
    public class AutentificationRequest
    {
        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
