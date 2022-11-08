using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Course;
using RLPortalBackend.Models.CourseSection;
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
        public async Task<CourseDto> GetCourseByIdAsync(Guid id)
        {

        }

        /// <summary>
        /// Get all preview courses 
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<PreviewCourseDto>), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet]
        public async Task<ICollection<PreviewCourseDto>> GetPreviewCoursesAsync()
        {

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

        }

    }
}
