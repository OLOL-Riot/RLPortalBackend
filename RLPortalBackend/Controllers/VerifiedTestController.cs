using Microsoft.AspNetCore.Mvc;
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
    }
}
