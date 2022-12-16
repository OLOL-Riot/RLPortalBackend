using RLPortalBackend.Entities;

namespace RLPortalBackend.Repositories
{
    public interface ICourseSectionRepository
    {
        public Task CreateAsync(CourseSectionEntity newCourseSectionEntity);

        public Task<ICollection<CourseSectionEntity>> GetAsync();

        public Task<CourseSectionEntity> GetAsync(Guid id);

        public Task<ICollection<CourseSectionEntity>> GetAsync(ICollection<Guid> ids);
        
        public Task RemoveAsync(Guid id);
        public Task RemoveAsync(ICollection<Guid> ids);
        public Task UpdateAsync(Guid id, CourseSectionEntity updateCourseSectionEntity);
    }
}
