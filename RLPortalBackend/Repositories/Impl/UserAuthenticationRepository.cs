using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using RLPortalBackend.Entities;
using RLPortalBackend.Exceptions;
using RLPortalBackend.Helpers;
using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;
using System.Text.RegularExpressions;

namespace RLPortalBackend.Repositories.Impl
{
    /// <summary>
    /// UserAuthenticationRepository for Postgres
    /// </summary>
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {

        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IUserStore<UserEntity> _userStore;
        private readonly IUserEmailStore<UserEntity> _emailStore;
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
            UserManager<UserEntity> userManager,
            IUserStore<UserEntity> userStore,
            SignInManager<UserEntity> signInManager,
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
        /// <returns></returns>
        /// <exception cref="UserNameNotFoundException"></exception>
        /// <exception cref="WrongPasswordException"></exception>
        public async Task<LoginResponseDto> LoginAsync(AutentificationRequestDto request)
        {
            var resultLogin = await _userManager.FindByNameAsync(request.Login);
            if(resultLogin == null)
            {
                throw new UserNameNotFoundException($"Login {request.Login} not found");
            }


            var result = await _signInManager.PasswordSignInAsync(request.Login, request.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation($"UserEntity login in account: {request.Login}");
                var user = await _userManager.FindByNameAsync(request.Login);
                var role = await _userManager.GetRolesAsync(user);
                string token = _jwtHelper.CreateToken(user, role[0]);
                return new LoginResponseDto(token);
            }
            throw new WrongPasswordException("Wrong password");
        }

 
        /// <summary>
        /// UserEntity registration
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="InvalidEmailException"></exception>
        /// <exception cref="InvalidPasswordException"></exception>
        /// <exception cref="UserNameAlredyExistsException"></exception>
        /// <exception cref="EmailAlredyExistsException"></exception>
        public async Task RegistrateAsync(UserDto input)
        {
            if (!Regex.IsMatch(input.Email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase))
                throw new InvalidEmailException("Invalid email");

            if (!Regex.IsMatch(input.Password, @"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,}$"))
            {
                throw new InvalidPasswordException("Invalid password");
            }
            if (_userManager.FindByNameAsync(input.Login).Result != null)
            {
                throw new UserNameAlredyExistsException($"Login {input.Login} alredy exists");
            }
            if (_userManager.FindByEmailAsync(input.Email).Result != null)
            {
                throw new EmailAlredyExistsException($"Email {input.Email} alredy exists");
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
                _logger.LogInformation($"UserEntity {input.Login} created");
                await _userManager.AddToRoleAsync(user, "UserEntity");

            }

        }

     
        /// <summary>
        /// Giving role by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="EmailNotFoundException"></exception>
        public async Task GiveRoleToUserAsync(ChangeRoleRequestDto email)
        {
            var user = await _userManager.FindByEmailAsync(email.UserEmail);
            if (user == null)
            {
                throw new EmailNotFoundException($"Email {email.UserEmail} not found");
            }

            if (email.Role != "Administrator" && email.Role != "User")
            {
                throw new InvalidRoleException($"The role {email.Role} not found");
            }

            await _userManager.AddToRoleAsync(user, email.Role);

            if (email.Role.Equals("Administrator")) await _userManager.RemoveFromRoleAsync(user, "User");
            else if (email.Role.Equals("User")) await _userManager.RemoveFromRoleAsync(user, "Administrator");
        }

        private UserEntity CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UserEntity>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UserEntity)}'. " +
                    $"Ensure that '{nameof(UserEntity)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<UserEntity> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<UserEntity>)_userStore;
        }


    }
}

