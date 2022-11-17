using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Services;
using System.Security.Claims;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// VerifiedTestController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VerifiedTestController : Controller
    {
        private readonly IVerifiedTestService _verifiedTestService;

        /// <summary>
        /// Constructor for VerifiedTestController
        /// </summary>
        /// <param name="verifiedTestService">verifiedTestService</param>
        public VerifiedTestController(IVerifiedTestService verifiedTestService)
        {
            _verifiedTestService = verifiedTestService;
        }

        /// <summary>
        /// Send the solved test to verify 
        /// (Permissions: UserEntity, Administrator)
        /// </summary>
        /// <param name="solvedTest">solvedTest</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(VerifiedTestDto), 201)]

        [HttpPost]
        [Authorize(Roles = "UserEntity, Administrator")]
        public async Task<IActionResult> Post(SolvedTestDto solvedTest)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            VerifiedTestDto createdVerifiedTest = await _verifiedTestService.CreateAsync(solvedTest, userId);
            return CreatedAtAction(nameof(GetAllVerifiedTests), new { id = createdVerifiedTest.Id }, createdVerifiedTest);

        }


        /// <summary>
        /// Get all verified tests 
        /// (Permissions: Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<VerifiedTestDto>), 200)]

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ICollection<VerifiedTestDto>> GetAllVerifiedTests()
        {
            return await _verifiedTestService.GetAsync();
        }

        /// <summary>
        /// Get the verified test by id 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="verifiedTestId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(VerifiedTestDto),200)]

        [HttpGet("{verifiedTestId:length(36)}")]
        [Authorize(Roles = "UserEntity, Administrator")]
        public async Task<VerifiedTestDto> GetVerifiedTestById(Guid verifiedTestId)
        {
            return await _verifiedTestService.GetByIdAsync(verifiedTestId);
        }

        /// <summary>
        /// Get all verified tests for current user 
        /// (Permissions: UserEntity, Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<VerifiedTestDto>), 200)]

        [HttpGet("CurrentUser")]
        [Authorize(Roles = "UserEntity, Administrator")]
        public async Task<ICollection<VerifiedTestDto>> GetCurrentUserVerifiedTests()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await _verifiedTestService.GetByUserIdAsync(userId);
        }

        /// <summary>
        /// Get all verified tests for specific user 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<VerifiedTestDto>), 200)]

        [HttpGet("SpecificUser/{userId:length(36)}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ICollection<VerifiedTestDto>> GetSpecificUserVerifiedTests(Guid userId)
        {
            return await _verifiedTestService.GetByUserIdAsync(userId);
        }

    }
}
