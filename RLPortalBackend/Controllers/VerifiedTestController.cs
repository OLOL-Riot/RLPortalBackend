using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Services;
using RLPortalBackend.Services.Impl;

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

        [HttpPost]
        [Authorize(Roles = "User, Administrator")]
        public async Task<IActionResult> Post(SolvedTestDto solvedTest)
        {
            VerifiedTestDto createdVerifiedTest = await _verifiedTestService.CreateAsync(solvedTest, User.Identity.Name);
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
            return await _verifiedTestService.GetByUserIdAsync(User.Identity.Name);
        }

        [HttpGet("SpecificUser/{username}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ICollection<VerifiedTestDto>> GetSpecificUserVerifiedTests(string username)
        {
            return await _verifiedTestService.GetByUserIdAsync(username);
        }

    }
}
