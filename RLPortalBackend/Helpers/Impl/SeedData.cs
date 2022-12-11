using Microsoft.AspNetCore.Identity;
using RLPortalBackend.Entities;

namespace RLPortalBackend.Helpers.Impl
{
    /// <summary>
    /// SeedData - make roles and admin account in postgres database
    /// </summary>
    public class SeedData: ISeedData
    {
        private readonly IConfiguration _configuration;

        public SeedData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Seed roles and user in database
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public void Seed(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);

        }

        /// <summary>
        /// Seed users to Postgres
        /// </summary>
        /// <param name="userManager"></param>
        private void SeedUsers(UserManager<UserEntity> userManager)
        {


            if (userManager.FindByNameAsync(_configuration["Admin:Login"]).Result == null)
            {
                var user = new UserEntity
                {
                    FirstName = _configuration["Admin:Firstname"],
                    LastName = _configuration["Admin:Lastname"],
                    UserName = _configuration["Admin:Login"],
                    Email = _configuration["Admin:Email"],
                    EmailConfirmed = true

                };
                var result = userManager.CreateAsync(user, _configuration["Admin:Password"]).Result;

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
        private void SeedRoles(RoleManager<IdentityRole> roleManager)
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
