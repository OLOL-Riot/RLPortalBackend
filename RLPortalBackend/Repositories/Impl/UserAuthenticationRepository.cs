using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Helpers;
using RLPortalBackend.Models.Autentification;


namespace RLPortalBackend.Repositories.Impl
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<UserAuthenticationRepository> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly IJWTHelper _jwtHelper;
        

        public UserAuthenticationRepository(
            IJWTHelper jwtHelper,
            IConfiguration configuration,
            UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            ILogger<UserAuthenticationRepository> logger,
            IEmailSender emailSender)
        {
            _jwtHelper = jwtHelper;
            _configuration = configuration;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<string> LoginAsync(AutentificationRequest request)
        { 
            var result = await _signInManager.PasswordSignInAsync(request.Login, request.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("succeeded");
                var user = await _userManager.FindByNameAsync(request.Login);
                var role = await _userManager.GetRolesAsync(user);
                string token = _jwtHelper.CreateToken(user, role[0]);
                return token;
            }
            return null;
        }

        public async Task RegistrateAsync(UserModel input)
        {
            var user = CreateUser();

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.UserName = input.UserName;

            await _userStore.SetUserNameAsync(user, input.UserName, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created");
                await _userManager.AddToRoleAsync(user, "User");

            }

        }


        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }


    }
}

