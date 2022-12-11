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
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public static void Seed(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        /// <summary>
        /// Seed users to Postgres
        /// </summary>
        /// <param name="userManager"></param>
        private static void SeedUsers(UserManager<UserEntity> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new UserEntity
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@test.com",
                    EmailConfirmed = true

                };
                var result = userManager.CreateAsync(user, "Password@1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
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
