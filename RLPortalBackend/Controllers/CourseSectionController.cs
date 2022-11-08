using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Services;

namespace RLPortalBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CourseSectionController : ControllerBase
    {

        private readonly ICourseSectionService _courseSectionService;

        public CourseSectionController(ICourseSectionService courseSectionService)
        {
            _courseSectionService = courseSectionService;
        }

        [HttpGet("get")]
        public async Task<ICollection<CourseSectionDto>> GetCourseSectionDtosAsync()
        {
            return await _courseSectionService.GetAsync();
        }

        [HttpGet("get/{id:length(36)}")]
        public async Task<CourseSectionDto> GetCourseSectionByIdAsync(Guid id)
        {
            return await _courseSectionService.GetByIdAsync(id);
        }

        [HttpDelete("remove/{id:length(36)}")]
        public async Task<ActionResult> RemoveCourseSectionById(Guid id)
        {
            await _courseSectionService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<CourseSectionDto> CreateNewCourseSection([FromBody] NewCourseSectionDto input)
        {
            return await _courseSectionService.CreateAsync(input);
        }

        




    }
}
