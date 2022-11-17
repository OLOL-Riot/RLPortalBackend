using RLPortalBackend.Entities;
using RLPortalBackend.Models.Course;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// ICourseRepository
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Create new course in source
        /// </summary>
        /// <param name="newCourseEntity"></param>
        /// <returns></returns>
        public Task CreateAsync(CourseEntity newCourseEntity);

        /// <summary>
        /// Get all courses from source
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<CourseEntity>> GetCoursesAsync();

        /// <summary>
        /// Get the course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CourseEntity> GetCourseByIdAsync(Guid id);

        /// <summary>
        /// Update the course by id in source
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCourseEntity"></param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, CourseEntity updateCourseEntity);

        /// <summary>
        /// Remove the course by id in source
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
