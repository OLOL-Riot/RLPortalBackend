using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// Autentification data
    /// </summary>
    public class AutentificationRequestDto
    {
        /// <summary>
        /// Login
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
