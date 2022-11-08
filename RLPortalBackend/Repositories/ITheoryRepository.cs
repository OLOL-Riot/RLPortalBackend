using RLPortalBackend.Entities;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// ITheoryRepository
    /// </summary>
    public interface ITheoryRepository
    {
        public Task CreateAsync(TheoryEntity newTheory);

        public Task<ICollection<TheoryEntity>> GetAsync();

        public Task<TheoryEntity> GetAsync(Guid id);

        public Task RemoveAsync(Guid id);

        public Task UpdateAsync(Guid id, TheoryEntity updatedTheory);




    }
}
