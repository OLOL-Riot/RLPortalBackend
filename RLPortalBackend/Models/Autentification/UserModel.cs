using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// UserModel models to auth
    /// </summary>
    public class UserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string? PhoneNumber { get; init; }

        public string ConfirmPassword { get; set; }
    }
}