using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Autentification;
using RLPortalBackend.Repositories;

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
            await _auth.RegistrateAsync(input);
            return Created("user", input);
        }


        [HttpPost("roles"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GiveRole(EmailAndRole emailAndRole)
        {
            await _auth.GiveRoleToUserAsync(emailAndRole);
            return Ok();
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


    }
}
