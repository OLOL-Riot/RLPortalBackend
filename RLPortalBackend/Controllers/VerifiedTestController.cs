using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Services;
using System.Security.Claims;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerifiedTestController : Controller
    {
        private readonly IVerifiedTestService _verifiedTestService;

        public VerifiedTestController(IVerifiedTestService verifiedTestService)
        {
            _verifiedTestService = verifiedTestService;
        }

        [HttpPost]
        [Authorize(Roles = "User, Administrator")]
        public async Task<IActionResult> Post(SolvedTestDto solvedTest)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            VerifiedTestDto createdVerifiedTest = await _verifiedTestService.CreateAsync(solvedTest, userId);
            return CreatedAtAction(nameof(GetAllVerifiedTests), new { id = createdVerifiedTest.Id }, createdVerifiedTest);

        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ICollection<VerifiedTestDto>> GetAllVerifiedTests()
        {
            return await _verifiedTestService.GetAsync();
        }

        [HttpGet("{verifiedTestId:length(36)}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<VerifiedTestDto> GetVerifiedTestById(Guid verifiedTestId)
        {
            return await _verifiedTestService.GetByIdAsync(verifiedTestId);
        }

        [HttpGet("CurrentUser")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ICollection<VerifiedTestDto>> GetCurrentUserVerifiedTests()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await _verifiedTestService.GetByUserIdAsync(userId);
        }

        [HttpGet("SpecificUser/{userId:length(36)}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ICollection<VerifiedTestDto>> GetSpecificUserVerifiedTests(Guid userId)
        {
            return await _verifiedTestService.GetByUserIdAsync(userId);
        }

    }
}
