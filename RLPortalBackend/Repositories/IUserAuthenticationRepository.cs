using RLPortalBackend.Models.Autentification;

namespace RLPortalBackend.Repositories
{
    public interface IUserAuthenticationRepository
    {
        public Task RegistrateAsync(UserModel input);
    }
}
