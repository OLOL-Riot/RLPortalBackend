using Microsoft.AspNetCore.Identity;
using RLPortalBackend.Entities;

namespace RLPortalBackend.Helpers
{
    /// <summary>
    /// SeedData - make roles and admin account in postgres database
    /// </summary>
    public static class SeedData
    {

        /// <summary>
        /// Seed roles and user in database
        /// </summary>
        /// <param name="roleManager"></param>
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
        }

        /// <summary>
        /// Seed roles to Postgres
        /// </summary>
        /// <param name="roleManager"></param>
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }

    }
}
