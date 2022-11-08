using RLPortalBackend.Models.CourseSection;

namespace RLPortalBackend.Services
{
    public interface ICourseSectionService
    {
        public Task<CourseSectionDto> CreateAsync(NewCourseSectionDto newCourseSectionDto);

        public Task<ICollection<CourseSectionDto>> GetAsync();

        public Task<CourseSectionDto> GetByIdAsync(Guid id);

        public Task UpdateAsync(Guid id, NewCourseSectionDto newCourseSectionDto);

        public Task RemoveAsync(Guid id);
    }
}
