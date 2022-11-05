using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using RLPortalBackend.Entities;
using RLPortalBackend.Exeption;
using RLPortalBackend.Helpers;
using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;
using System.Net;
using System.Text.RegularExpressions;

namespace RLPortalBackend.Repositories.Impl
{
    /// <summary>
    /// UserAuthenticationRepository for Postgres
    /// </summary>
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

        /// <summary>
        /// UserAuthenticationRepository constructor
        /// </summary>
        /// <param name="jwtHelper"></param>
        /// <param name="configuration"></param>
        /// <param name="userManager"></param>
        /// <param name="userStore"></param>
        /// <param name="signInManager"></param>
        /// <param name="logger"></param>
        /// <param name="emailSender"></param>
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

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns>JWT token</returns>
        /// <exception cref="HttpException"></exception>
        public async Task<JWT> LoginAsync(AutentificationRequest request)
        {
            var resultLogin = await _userManager.FindByNameAsync(request.Login);
            if (resultLogin == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, $"Login {request.Login} not found");
            }


            var result = await _signInManager.PasswordSignInAsync(request.Login, request.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation($"User login in account: {request.Login}");
                var user = await _userManager.FindByNameAsync(request.Login);
                var role = await _userManager.GetRolesAsync(user);
                string token = _jwtHelper.CreateToken(user, role[0]);
                return new JWT(token);
            }
            throw new HttpException(HttpStatusCode.BadRequest, "Wrong password");
        }


        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="HttpException"></exception>
        public async Task RegistrateAsync(UserModel input)
        {
            string pattern = @"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,}$";
            string patternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            if (!Regex.IsMatch(input.Email, patternEmail, RegexOptions.IgnoreCase))
                throw new HttpException(HttpStatusCode.BadRequest, "Invalid email");

            if (!Regex.IsMatch(input.Password, pattern))
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Invalid password");
            }
            if (_userManager.FindByNameAsync(input.Login).Result != null)
            {
                throw new HttpException(HttpStatusCode.Conflict, $"Login {input.Login} alredy exists");
            }
            if (_userManager.FindByEmailAsync(input.Email).Result != null)
            {
                throw new HttpException(HttpStatusCode.Conflict, $"Email {input.Email} alredy exists");
            }
            var user = CreateUser();

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.UserName = input.Login;

            await _userStore.SetUserNameAsync(user, input.Login, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User {input.Login} created");
                await _userManager.AddToRoleAsync(user, "User");

            }

        }

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="input"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="PasswordMatchException"></exception>
        /// <exception cref="InvalidPasswordException"></exception>
        /// <exception cref="WrongPasswordException"></exception>
        public async Task ChangePasswordAsync(ChangePasswordDto input, Guid userId)
        {
            if (input.CurrentPassword.Equals(input.NewPassword))
            {
                throw new PasswordMatchException("Passwords match");
            }
            if (!Regex.IsMatch(input.NewPassword, @"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,}$"))
            {
                throw new InvalidPasswordException("Invalid password");
            }
            User user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ChangePasswordAsync(user, input.CurrentPassword, input.NewPassword);
            if (!result.Succeeded)
            {
                throw new WrongPasswordException("Wrong password");
            }

        }


        /// <summary>
        /// Giving role by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="HttpException"></exception>
        public async Task GiveRoleToUserAsync(EmailAndRole email)
        {
            var user = await _userManager.FindByEmailAsync(email.UserEmail);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, email.Role);
                if (email.Role.Equals("Administrator")) await _userManager.RemoveFromRoleAsync(user, "User");
                if (email.Role.Equals("User")) await _userManager.RemoveFromRoleAsync(user, "Administrator");
            }
            throw new HttpException(HttpStatusCode.BadRequest, $"Email {email.UserEmail} not found");
        }

        /// <summary>
        /// Create instance of User
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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

