using GeographyPortal.Models.Autentification;
using Microsoft.AspNetCore.Mvc;

namespace GeographyPortal.Services
{
    public interface IUserAuthenticationRepository
    {
        public Task RegistrateAsync(UserModel input);
    }
}
