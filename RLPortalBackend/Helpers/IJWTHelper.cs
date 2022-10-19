using RLPortalBackend.Models.Autentification;

namespace RLPortalBackend.Helpers
{
    public interface IJWTHelper
    {
        public string CreateToken(User user, string role);
    }
}
