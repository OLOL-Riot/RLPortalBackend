using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Exceptions;
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
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]

        [HttpPost("registration")]
        public async Task<ActionResult> Registration(UserModel input)
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

        [HttpPost("roles"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GiveRole(EmailAndRole emailAndRole)
        {
            await _auth.GiveRoleToUserAsync(emailAndRole);
            return Ok();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="autentificationRequest"></param>
        /// <returns><see cref="JWT"/></returns>
        /// <exception cref="HttpException"></exception>
        /// <response code="200">Registration completed successfully</response>
        /// <response code="400">Wrong password</response> 
        /// <response code="404">Login not found</response>
        [ProducesResponseType(typeof(JWT), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        [HttpPost("login")]
        public async Task<ActionResult> Login(AutentificationRequest autentificationRequest)
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
        /// </summary>
        /// <param name="changePasswordDto"></param>
        /// (Permissions: Administrator, User) 
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


    }
}
