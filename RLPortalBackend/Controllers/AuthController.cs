using RLPortalBackend.Models.Autentification;
using RLPortalBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserAuthenticationRepository _auth;

        public AuthController(IUserAuthenticationRepository auth)
        {
            _auth = auth;
        }

        [HttpPost(Name = "Registarion")]
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
