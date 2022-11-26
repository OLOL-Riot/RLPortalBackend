using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;
using RLPortalBackend.Repositories;
using System.Data;
using System.Security.Claims;
using InvalidDataException = RLPortalBackend.Exceptions.InvalidDataException;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// Controller for Authentification
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : Controller
    {
        private readonly IUserAuthenticationRepository _auth;
        /// <summary>
        /// AuthentificationController constructor
        /// </summary>
        /// <param name="auth"></param>
        public AuthentificationController(IUserAuthenticationRepository auth)
        {
            _auth = auth;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <response code="200">Registration completed successfully</response>
        /// <response code="400">Invalid email or password</response>
        /// <response code="409">Email or Username alredy exists</response>
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]

        [HttpPost("registration")]
        public async Task<ActionResult> Registration(UserDto input)
        {
            await _auth.RegistrateAsync(input);
            return Created("user", input);
        }

        /// <summary>
        /// Change role for specific user
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="emailAndRole"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        [HttpPost("change/role"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GiveRole(ChangeRoleRequestDto emailAndRole)
        {
            await _auth.GiveRoleToUserAsync(emailAndRole);
            return Ok();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="autentificationRequest"></param>
        /// <returns><see cref="LoginResponseDto"/></returns>
        /// <exception cref="HttpException"></exception>
        /// <response code="200">Registration completed successfully</response>
        /// <response code="400">Wrong password</response> 
        /// <response code="404">Login not found</response>
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        [HttpPost("login")]
        public async Task<ActionResult> Login(AutentificationRequestDto autentificationRequest)
        {
            var token = await _auth.LoginAsync(autentificationRequest);
            if (token.Token != null)
            {
                return Ok(token);
            }
            return BadRequest("User not Found");
        }

        /// <summary>
        /// Change password 
        /// (Permissions: Administrator, User) 
        /// </summary>
        /// <param name="changePasswordDto"></param>
        /// <returns></returns>
        /// <response code="200">Password changed</response>
        /// <response code="400">Wrong password</response> 
        /// <response code="409">Passwords match</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]

        [Authorize(Roles = "Administrator, User")]
        [HttpPut("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _auth.ChangePasswordAsync(changePasswordDto, userId);
            
            return Ok(new {Message = "Password changed"});
        }

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpGet("confirm-email")]
        public async Task<ActionResult> ConfirmEmail(Guid id, string token)
        {
            await _auth.ConfirmEmail(id, token);
            return Ok();
        }

        /// <summary>
        /// Get current user data
        /// </summary>
        /// <returns></returns>

        [Authorize(Roles = "Administrator, User")]
        [HttpGet("current-user-data")]
        public async Task<CurrentUserDto> GetCurrentUserData()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await _auth.GetUserDataById(userId);
        }

        /// <summary>
        /// Change current user data
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]

        [Authorize(Roles = "User, Administrator")]
        [HttpPut("change-current-user-data")]
        public async Task<ActionResult> ChangeUserData(ChangeUserDataDto input)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _auth.ChangeUserDataAsync(input, userId);
            return Ok();

        }

        /// <summary>
        /// Send reset password token
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "User, Administrator")]
        [HttpPost("send-reset-token")]
        public async Task SendResetPasswordEmail()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _auth.SendResetPasswordEmail(userId);
        }

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpGet("reset-password")]
        public async Task<ActionResult> ResetPassword(Guid id, string token, string newPassword)
        {
            await _auth.ResetPassword(id, token, newPassword);
            return Ok();
        }
    }
}
