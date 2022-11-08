using RLPortalBackend.Entities;

namespace RLPortalBackend.Repositories
{
    public interface ICourseSectionRepository
    {
        public Task CreateAsync(CourseSectionEntity newCourseSectionEntity);

        public Task<ICollection<CourseSectionEntity>> GetAsync();

        public Task<CourseSectionEntity> GetAsync(Guid id);

        public Task RemoveAsync(Guid id);

        public Task UpdateAsync(Guid id, CourseSectionEntity updateCourseSectionEntity);
    }
}
