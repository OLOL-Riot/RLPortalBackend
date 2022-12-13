using Microsoft.AspNetCore.Identity;
using RLPortalBackend.Entities;

namespace RLPortalBackend.Helpers
{
    public interface ISeedData
    {
        /// <summary>
        /// Seed users to Postgres
        /// </summary>
        /// <param name="userManager"></param>
        public void Seed(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager);
    }
}
