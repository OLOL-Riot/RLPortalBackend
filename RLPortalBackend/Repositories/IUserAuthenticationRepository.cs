using RLPortal.Models.Autentification;
using Microsoft.AspNetCore.Mvc;

namespace RLPortal.Repositories
{
    public interface IUserAuthenticationRepository
    {
        public Task RegistrateAsync(UserModel input);
    }
}
