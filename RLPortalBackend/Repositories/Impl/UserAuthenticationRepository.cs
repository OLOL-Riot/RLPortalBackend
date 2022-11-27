using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.OpenApi.Writers;
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

        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IUserStore<UserEntity> _userStore;
        private readonly IUserEmailStore<UserEntity> _emailStore;
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
        /// <param name="mapper"></param>
        public UserAuthenticationRepository(
            IMapper mapper,
            IJWTHelper jwtHelper,
            IConfiguration configuration,
            UserManager<UserEntity> userManager,
            IUserStore<UserEntity> userStore,
            SignInManager<UserEntity> signInManager,
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
            _mapper = mapper;
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
            if (resultLogin == null)
            {
                _logger.LogInformation($"User with username {request.Login} not found");
                throw new UserNameNotFoundException($"Login {request.Login} not found");
            }
            if (!resultLogin.EmailConfirmed)
            {
                await SendConfirmEmail(resultLogin);
                throw new EmailNotConfirmedException("Email not confirmed");
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
                await SendConfirmEmail(user);
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
                throw new PasswordMatchException("New passwords equals old password");
            }
            if (!Regex.IsMatch(input.NewPassword, @"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,}$"))
            {
                throw new InvalidPasswordException("Invalid new password");
            }
            UserEntity user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ChangePasswordAsync(user, input.CurrentPassword, input.NewPassword);
            if (!result.Succeeded)
            {
                throw new WrongPasswordException("Current password is incorrect");
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
            var currentUser = await _userManager.FindByIdAsync(userId.ToString());

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

        /// <summary>
        /// Send confirmation email to EmailSenderService by Rabbit
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task SendConfirmEmail(UserEntity user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string userId = user.Id;
            string newToken = token.Replace("+", "%2B").Replace("/", "%2F").Replace("==", "%3D%3D");
            string tempUrl = $"http://localhost:5242/api/Authentification/confirm-email?id={userId}&token={newToken}";
            var message = new MessageToSend(user.Email, "Confirm email", tempUrl);
            await _emailSender.SendEmail(message);
        }

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task ConfirmEmail(Guid id, string token)
        {
            UserEntity user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.ConfirmEmailAsync(user, token);
        }

        /// <summary>
        /// Get User Data By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public async Task<CurrentUserDto> GetUserDataById(Guid id)
        {
            var userEntity = await _userManager.FindByIdAsync(id.ToString());
            CurrentUserDto userDto = _mapper.Map<CurrentUserDto>(userEntity);
            return userDto;
        }
    }
}


