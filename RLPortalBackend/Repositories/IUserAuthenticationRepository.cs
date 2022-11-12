using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;

namespace RLPortalBackend.Repositories
{
    public interface IUserAuthenticationRepository
    {
        public Task RegistrateAsync(UserModel input);

        public Task<JWT> LoginAsync(AutentificationRequest request);

        public Task GiveRoleToUserAsync(EmailAndRole email);

        public Task ConfirmEmail(Guid id, string token);

    }
}
