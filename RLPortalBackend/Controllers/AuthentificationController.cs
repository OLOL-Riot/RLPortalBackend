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
            try
            {
                await _auth.RegistrateAsync(input);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("registration/admin"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> RegistrationAdmin(UserModel input)
        {
            try
            {
                await _auth.RegistrateAdminAsync(input);
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
            if (token != null)
            {
                return Ok(token);
            }
            return BadRequest("User not Found");
            
        }


    }
}
