using RLPortalBackend.Entities;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// ITheoryRepository
    /// </summary>
    public interface ITheoryRepository
    {
        /// <summary>
        /// Create Theory
        /// </summary>
        /// <param name="newTheory"></param>
        /// <returns></returns>
        public Task CreateAsync(TheoryEntity newTheory);

        /// <summary>
        /// Get all Theory
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<TheoryEntity>> GetAsync();

        /// <summary>
        /// Get Theory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TheoryEntity> GetAsync(Guid id);

        /// <summary>
        /// Remove Theory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);

        /// <summary>
        /// Update Theory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedTheory"></param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, TheoryEntity updatedTheory);




    }
}
