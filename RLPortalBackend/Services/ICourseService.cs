using RLPortalBackend.Models.Course;

namespace RLPortalBackend.Services
{
    /// <summary>
    /// ICourseService
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Create new course
        /// </summary>
        /// <param name="createCourseDto"></param>
        /// <returns></returns>
        public Task<CourseDto> CreateAsync(CreateCourseDto createCourseDto);

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<CourseDto>> GetCoursesAsync();

        /// <summary>
        /// Get the course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<PageCourseDto> GetPageCourseByIdAsync(Guid id);

        /// <summary>
        /// Get the course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CourseDto> GetCourseByIdAsync(Guid id);

        /// <summary>
        /// Get all preview courses
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<PreviewCourseDto>> GetAllPreviewCourses();

        /// <summary>
        /// Update the course by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCourseDto"></param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, UpdateCourseDto updateCourseDto);

        /// <summary>
        /// Remove the course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);

    }
}
