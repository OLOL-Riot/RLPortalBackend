using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Autentification;

namespace RLPortalBackend.Helpers.Impl
{
    /// <summary>
    /// SeedData - make roles and admin account in postgres database
    /// </summary>
    public class SeedData: ISeedData
    {
        private readonly AdminOptions _options;

        public SeedData(AdminOptions options)
        {
            _options = options;
        }



        /// <summary>
        /// Seed roles and user in database
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public async Task SeedAsync(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
            SeedUsers(userManager);

        }

        /// <summary>
        /// Seed users to Postgres
        /// </summary>
        /// <param name="userManager"></param>
        private void SeedUsers(UserManager<UserEntity> userManager)
        {

            AdminOptions adminOptions = _options;

            if (userManager.FindByNameAsync(adminOptions.Login).Result == null)
            {
                var user = new UserEntity
                {
                    FirstName = adminOptions.Firstname,
                    LastName = adminOptions.Lastname,
                    UserName = adminOptions.Login,
                    Email = adminOptions.Email,
                    EmailConfirmed = true

                };
                var result = userManager.CreateAsync(user, adminOptions.Password).Result;

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
        private async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                await roleManager.CreateAsync(role);
            }
        }

    }
}
