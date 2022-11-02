using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Exeption;
using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;
using RLPortalBackend.Repositories;

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
        /// User registration method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <response code="200">Registration completed successfully</response>
        /// <response code="400">Invalid email or password</response>
        /// <response code="409">Email or Username alredy exists</response>
        [HttpPost("registration")]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Registration(UserModel input)
        {
            await _auth.RegistrateAsync(input);
            return Created("user", input);
        }

        /// <summary>
        /// User role change method 
        /// </summary>
        /// <param name="emailAndRole"></param>
        /// <returns></returns>
        [HttpPost("roles"), Authorize(Roles = "Administrator")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> GiveRole(EmailAndRole emailAndRole)
        {
            await _auth.GiveRoleToUserAsync(emailAndRole);
            return Ok();
        }

        /// <summary>
        /// User login method
        /// </summary>
        /// <param name="autentificationRequest"></param>
        /// <returns><see cref="JWT"/></returns>
        /// <exception cref="HttpException"></exception>
        /// <response code="200">Registration completed successfully</response>
        /// <response code="400">Wrong password</response> 
        /// <response code="404">Login not found</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(JWT), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Login(AutentificationRequest autentificationRequest)
        {
            var token = await _auth.LoginAsync(autentificationRequest);
            if (token.Token != null)
            {
                return Ok(token);
            }
            return BadRequest("User not Found");

        }


    }
}
