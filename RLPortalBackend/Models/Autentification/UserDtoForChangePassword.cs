using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// Class for current password and new password
    /// </summary>
    public class UserDtoForChangePassword
    {
        /// <summary>
        /// CurrentPassword
        /// </summary>
        [Required]
        public string CurrentPassword { get; set; }

        /// <summary>
        /// NewPassword
        /// </summary>
        [Required]
        public string NewPassword { get; set; }
    }
}
