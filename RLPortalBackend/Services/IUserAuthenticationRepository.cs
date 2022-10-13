using RLPortalBackend.Models.Autentification;
using Microsoft.AspNetCore.Mvc;

namespace RLPortalBackend.Services
{
    public interface IUserAuthenticationRepository
    {
        public Task RegistrateAsync(UserModel input);
    }
}
