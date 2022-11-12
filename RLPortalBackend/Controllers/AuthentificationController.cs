using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Autentification;
using RLPortalBackend.Repositories;
using System.Security.Claims;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : Controller
    {
        private readonly IUserAuthenticationRepository _auth;

        public AuthentificationController(IUserAuthenticationRepository auth)
        {
            _auth = auth;
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Registration(UserModel input)
        {
            try
            {
                await _auth.RegistrateAsync(input);
                return Created("user", input);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPost("roles"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GiveRole(EmailAndRole emailAndRole)
        {
            try
            {
                await _auth.GiveRoleToUserAsync(emailAndRole);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

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

        [HttpPost("confirm-email")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> ConfirmEmail(string token)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _auth.ConfirmEmail(userId, token);
            return Ok();
        }


    }
}
