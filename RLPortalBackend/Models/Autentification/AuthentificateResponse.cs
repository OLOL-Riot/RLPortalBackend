namespace RLPortalBackend.Models.Autentification
{
    public class AuthentificateResponse : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }

        public AuthentificateResponse(User user,string token)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Token = token;
        }
    }
}
