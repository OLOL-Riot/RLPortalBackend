using RLPortalBackend.Models.Autentification;
using RLPortalBackend.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Registration")]
        public async Task<ActionResult> Registration(UserModel input)
        {
            try
            {
                await _auth.RegistrateAsync(input);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
        }
    }
}
