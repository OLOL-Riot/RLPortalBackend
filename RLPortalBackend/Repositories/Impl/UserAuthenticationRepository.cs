using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;

using RLPortalBackend.Container.Messages;

using RLPortalBackend.Entities;
using RLPortalBackend.Exceptions;
using RLPortalBackend.Helpers;
using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;

using RLPortalBackend.Services;

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
        private readonly IEmailSenderService _emailSender;
        private readonly IConfiguration _configuration;
        private readonly IJWTHelper _jwtHelper;

        private readonly IMapper _mapper;



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
            IMapper mapper,
            IJWTHelper jwtHelper,
            IConfiguration configuration,
            UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            ILogger<UserAuthenticationRepository> logger,
            IEmailSenderService emailSender)
        {
            _mapper = mapper;
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
        public async Task<JWT> LoginAsync(AutentificationRequest request)
        {
            var resultLogin = await _userManager.FindByNameAsync(request.Login);
            if (resultLogin == null)
            {
                _logger.LogInformation($"User with username {request.Login} not found");
                throw new UserNameNotFoundException($"Login {request.Login} not found");
            }
            if (!resultLogin.EmailConfirmed)
            {
                throw new MailNotConfirmed("Your email not confirmed.");
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
            throw new WrongPasswordException("Wrong password");
        }


        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="InvalidEmailException"></exception>
        /// <exception cref="InvalidPasswordException"></exception>
        /// <exception cref="UserNameAlredyExistsException"></exception>
        /// <exception cref="EmailAlredyExistsException"></exception>
        public async Task RegistrateAsync(UserModel input)
        {
            if (!Regex.IsMatch(input.Email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase))

            {
                _logger.LogInformation($"Mail {input.Email} non valid");
                throw new InvalidEmailException("Invalid email");
            }
            if (!Regex.IsMatch(input.Password, @"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,}$"))
            {
                _logger.LogInformation($"Password {input.Password} non valid");

                throw new InvalidEmailException("Invalid email");

                if (!Regex.IsMatch(input.Password, @"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,}$"))
                {

                    throw new InvalidPasswordException("Invalid password");
                }
                if (_userManager.FindByNameAsync(input.Login).Result != null)
                {

                    _logger.LogInformation($"User with {input.Login} alredy exists");

                    throw new UserNameAlredyExistsException($"Login {input.Login} alredy exists");
                }
                if (_userManager.FindByEmailAsync(input.Email).Result != null)
                {

                    _logger.LogInformation($"User with email {input.Email} alredy exists");

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

                    await SendConfirmEmail(user);

                    _logger.LogInformation($"User {input.Login} created");
                    await _userManager.AddToRoleAsync(user, "User");

                }

            }
        }


        /// <summary>
        /// Giving role by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="EmailNotFoundException"></exception>
        public async Task GiveRoleToUserAsync(EmailAndRole email)
        {
            var user = await _userManager.FindByEmailAsync(email.UserEmail);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, email.Role);
                _logger.LogInformation($"User with {email.UserEmail} get new role {email.Role}");
                if (email.Role.Equals("Administrator")) await _userManager.RemoveFromRoleAsync(user, "User");
                if (email.Role.Equals("User")) await _userManager.RemoveFromRoleAsync(user, "Administrator");
            }
            throw new EmailNotFoundException($"Email {email.UserEmail} not found");
        }


        /// <summary>
        /// Change user data
        /// </summary>
        /// <param name="changeUserDataDto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="UserNameAlredyExistsException"></exception>
        /// <exception cref="EmailAlredyExistsException"></exception>
        /// <exception cref="InvalidEmailException"></exception>
        public async Task ChangeUserDataAsync(ChangeUserDataDto changeUserDataDto, Guid userId)
        {
            User currentUser = await _userManager.FindByIdAsync(userId.ToString());

            if (currentUser.UserName != changeUserDataDto.UserName & changeUserDataDto.UserName != null ? await _userManager.FindByNameAsync(changeUserDataDto.UserName) != null : false)
            {
                throw new UserNameAlredyExistsException($"UserName {changeUserDataDto.UserName} alredy exists");
            }

            if (changeUserDataDto.Email != null ? !Regex.IsMatch(changeUserDataDto.Email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase) : false)
            {
                throw new InvalidEmailException("Invalid email");
            }

            if (currentUser.Email != changeUserDataDto.Email & changeUserDataDto.Email != null ? await _userManager.FindByEmailAsync(changeUserDataDto.Email) != null: false)
            {
                throw new EmailAlredyExistsException($"Email {changeUserDataDto.Email} alredy exists");
            }
            bool flag = false;

            currentUser.FirstName = changeUserDataDto.FirstName ?? currentUser.FirstName;
            currentUser.LastName = changeUserDataDto.LastName ?? currentUser.LastName;
            currentUser.PhoneNumber = changeUserDataDto.PhoneNumber ?? currentUser.PhoneNumber;
            if (changeUserDataDto.Email != null & currentUser.Email != changeUserDataDto.Email)
            {
                flag = true;
                currentUser.Email = changeUserDataDto.Email;
                currentUser.EmailConfirmed = false;
            }
            
            currentUser.UserName = changeUserDataDto.UserName ?? currentUser.UserName;
            
            await _userManager.UpdateAsync(currentUser);
            if (flag)
            {
                
                await SendConfirmEmail(await _userManager.FindByIdAsync(currentUser.Id));
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

        public async Task<User> GetUserByUsername(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        private async Task SendConfirmEmail(User user)
        {
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user);
            MessageToSend message = new MessageToSend(user.Email, "Confirm email", token.Result);
            await _emailSender.SendEmail(message);

        }

        public async Task ConfirmEmail(Guid id, string token)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.ConfirmEmailAsync(user, token);

        }




    }
}


