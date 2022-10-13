using RLPortalBackend.Models.Autentification;
using Microsoft.AspNetCore.Mvc;

namespace RLPortalBackend.Repositories
{
    public interface IUserAuthenticationRepository
    {
        public Task RegistrateAsync(UserModel input);

        public Task LoginAsync(AutentificationRequest request);
    }
}
