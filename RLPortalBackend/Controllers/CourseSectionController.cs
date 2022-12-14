using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Services;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// CourseSectionController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CourseSectionController : ControllerBase
    {

        private readonly ICourseSectionService _courseSectionService;

        public CourseSectionController(ICourseSectionService courseSectionService)
        {
            _courseSectionService = courseSectionService;
        }

        /// <summary>
        /// Get all CourseSection
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<CourseSectionDto>), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet]
        public async Task<ICollection<CourseSectionDto>> GetCourseSectionDtosAsync()
        {
            return await _courseSectionService.GetAsync();
        }

        /// <summary>
        /// Get page CourseSection by Id
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(PageCourseSectionDto), 200)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("page/{id:length(36)}")]
        public async Task<PageCourseSectionDto> GetPageCourseSectionByIdAsync(Guid id)
        {
            return await _courseSectionService.GetPageCourseSectionByIdAsync(id);
        }

        /// <summary>
        /// Get CourseSection by Id
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseSectionDto), 200)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("{id:length(36)}")]
        public async Task<CourseSectionDto> GetCourseSectionByIdAsync(Guid id)
        {
            return await _courseSectionService.GetCourseSectionByIdAsync(id);
        }

        /// <summary>
        /// Delete CourseSection by Id
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:length(36)}")]
        public async Task<ActionResult> RemoveCourseSectionById(Guid id)
        {
            await _courseSectionService.RemoveAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Create CourseSection
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseSectionDto), 201)]

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<CourseSectionDto>> CreateNewCourseSection([FromBody] CreateCourseSectionDto input)
        {
            var dto = await _courseSectionService.CreateAsync(input);
            return CreatedAtAction(nameof(GetCourseSectionByIdAsync), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// GetPreviews
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<PreviewCourseSectionDto>), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpPost("preview")]
        public async Task<ICollection<PreviewCourseSectionDto>> GetPreviews(ICollection<Guid> ids)
        {
            return await _courseSectionService.GetPreviewCourseSections(ids);
        }

        /// <summary>
        /// Update CourseSection by Id
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newCourseSectionDto"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:length(36)}")]
        public async Task<ActionResult> UpdateCourseSection(Guid id, UpdateCourseSectionDto newCourseSectionDto)
        {
            await _courseSectionService.UpdateAsync(id, newCourseSectionDto);
            return NoContent();
        }






    }
}
