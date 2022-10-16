using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// UserModel models to auth
    /// </summary>
    public class UserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string PhoneNumber { get; init; }

        [Required(ErrorMessage = "Confirm password is required")]
        public string ConfirmPassword { get; set; }
    }
}