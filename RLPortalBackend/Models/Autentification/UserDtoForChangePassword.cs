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
        public string CurrentPassword { get; set; }

        /// <summary>
        /// NewPassword
        /// </summary>
        public string NewPassword { get; set; }
    }
}
