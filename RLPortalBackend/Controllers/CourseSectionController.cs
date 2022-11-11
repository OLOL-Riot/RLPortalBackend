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
        [ProducesResponseType(typeof(ICollection<PageCourseSectionDto>), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet]
        public async Task<ICollection<PageCourseSectionDto>> GetCourseSectionDtosAsync()
        {
            return await _courseSectionService.GetAsync();
        }

        /// <summary>
        /// Get CourseSection by Id
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(PageCourseSectionDto), 200)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("page/{id:length(36)}")]
        public async Task<PageCourseSectionDto> GetCourseSectionByIdAsync(Guid id)
        {
            return await _courseSectionService.GetByIdAsync(id);
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
        [ProducesResponseType(typeof(PageCourseSectionDto), 201)]

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<PageCourseSectionDto>> CreateNewCourseSection([FromBody] NewCourseSectionDto input)
        {
            var dto = await _courseSectionService.CreateAsync(input);
            return CreatedAtAction(nameof(CreateNewCourseSection), dto);
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
        public async Task<ActionResult> UpdateCourseSection(Guid id, NewCourseSectionDto newCourseSectionDto)
        {
            await _courseSectionService.UpdateAsync(id, newCourseSectionDto);
            return NoContent();
        }






    }
}
