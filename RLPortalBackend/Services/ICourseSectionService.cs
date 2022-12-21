using RLPortalBackend.Models.CourseSection;

namespace RLPortalBackend.Services
{
    public interface ICourseSectionService
    {
        /// <summary>
        /// Create Course section
        /// </summary>
        /// <param name="createCourseSectionDto"></param>
        /// <returns></returns>
        public Task<CourseSectionDto> CreateAsync(CreateCourseSectionDto createCourseSectionDto);

        /// <summary>
        /// Get all Course sections
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<CourseSectionDto>> GetAsync();

        /// <summary>
        /// Get Page Course section by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<PageCourseSectionDto> GetPageCourseSectionByIdAsync(Guid id);

        /// <summary>
        /// Get Course section by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CourseSectionDto> GetCourseSectionByIdAsync(Guid id);

        /// <summary>
        /// Update Course section by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCourseSectionDto"></param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, UpdateCourseSectionDto updateCourseSectionDto);

        /// <summary>
        /// Delete Course section by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);

        /// <summary>
        /// Get previews course sections of courses
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<ICollection<PreviewCourseSectionDto>> GetPreviewCourseSections(ICollection<Guid> ids);
        Task RemoveAsync(ICollection<Guid> ids);
    }
}
