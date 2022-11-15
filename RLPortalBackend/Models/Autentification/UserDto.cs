using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// UserEntity model to authentification
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "ChangeRoleRequestDto is required")]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; init; }
    }
}