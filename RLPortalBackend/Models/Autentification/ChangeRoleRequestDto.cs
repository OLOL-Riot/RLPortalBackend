using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// Mail and role
    /// </summary>
    public class ChangeRoleRequestDto
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string UserEmail { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [Required]
        public string Role { get; set; }
    }
}
