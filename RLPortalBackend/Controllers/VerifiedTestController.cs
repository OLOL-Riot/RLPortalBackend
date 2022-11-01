using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Services;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerifiedTestController: Controller
    {
        private readonly IVerifiedTestService _verifiedTestService;

        public VerifiedTestController(IVerifiedTestService verifiedTestService)
        {
            _verifiedTestService = verifiedTestService;
        }

        //[HttpPost]
        //[Authorize(Roles = "User, Administrator")]
        //public async Task<IActionResult> Post(SolvedTestDto solvedTest)
        //{
            
        //}

    }
}
