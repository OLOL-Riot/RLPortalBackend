using RLPortalBackend.Models.CourseSection;

namespace RLPortalBackend.Services
{
    public interface ICourseSectionService
    {
        /// <summary>
        /// Create Course
        /// </summary>
        /// <param name="newCourseSectionDto"></param>
        /// <returns></returns>
        public Task<CourseSectionDto> CreateAsync(NewCourseSectionDto newCourseSectionDto);

        /// <summary>
        /// Get all Course
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<CourseSectionDto>> GetAsync();

        /// <summary>
        /// Get Course by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CourseSectionDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Update Course by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newCourseSectionDto"></param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, NewCourseSectionDto newCourseSectionDto);

        /// <summary>
        /// Delete Course by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);

        /// <summary>
        /// Get previews of courses
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<ICollection<PreviewCourseSectionDto>> GetPreviewCourse(ICollection<Guid> ids);
    }
}
