using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Course;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Services;
using RLPortalBackend.Services.Impl;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// CourseController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController: Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Get all courses 
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<CourseDto>), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet]
        public async Task<ICollection<CourseDto>> GetCoursesAsync()
        {
            return await _courseService.GetCoursesAsync();
        }

        /// <summary>
        /// Get course by id 
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseDto), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("{id:length(36)}")]
        public async Task<ActionResult<CourseDto>> GetCourseByIdAsync(Guid id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course is null)
            {
                return NotFound();
            }

            return course;
        }

        /// <summary>
        /// Get all preview courses 
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<PreviewCourseDto>), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("preview")]
        public async Task<ICollection<PreviewCourseDto>> GetPreviewCoursesAsync()
        {
            return await _courseService.GetAllPreviewCourses();
        }

        /// <summary>
        /// Create Course 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="createCourseDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseDto), 201)]

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateNewCourse([FromBody] CreateCourseDto createCourseDto)
        {
            CourseDto createdCourse = await _courseService.CreateAsync(createCourseDto);

            return CreatedAtAction(nameof(GetCourseByIdAsync), new { id = createdCourse.Id }, createdCourse);

        }

        /// <summary>
        /// Update Course by Id
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCourseDto"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "User, Administrator")]
        [HttpPut("{id:length(36)}")]
        public async Task<ActionResult> UpdateCourseSection(Guid id, UpdateCourseDto updateCourseDto)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course is null)
            {
                return NotFound();
            }

            await _courseService.UpdateAsync(id, updateCourseDto);

            return NoContent();
        }

        /// <summary>
        /// Delete Course by Id 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:length(36)}")]
        public async Task<ActionResult> RemoveCourseById(Guid id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course is null)
            {
                return NotFound();
            }

            await _courseService.RemoveAsync(id);

            return NoContent();

        }

    }
}
