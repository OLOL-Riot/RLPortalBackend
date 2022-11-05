namespace RLPortalBackend.Models.Autentification
{
    /// <summary>
    /// ChangeUserDataDto
    /// </summary>
    public class ChangeUserDataDto
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
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; init; }
    }
}
