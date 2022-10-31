using RLPortalBackend.Entities;

namespace RLPortalBackend.Helpers
{
    public interface IJWTHelper
    {
        public string CreateToken(User user, string role);
    }
}
