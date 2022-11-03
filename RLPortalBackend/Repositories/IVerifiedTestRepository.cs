using RLPortalBackend.Entities;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// The repository with verified tests
    /// </summary>
    public interface IVerifiedTestRepository
    {
        /// <summary>
        /// Create one VerifiedTest in source
        /// </summary>
        /// <param name="newVerifiedTestEntity"></param>
        /// <returns></returns>
        public Task CreateAsync(VerifiedTestEntity newVerifiedTestEntity);

        /// <summary>
        /// Get all of VerifiedTests
        /// </summary>
        /// <returns>Collection of Verified Tests</returns>
        public Task<ICollection<VerifiedTestEntity>> GetAsync();

        /// <summary>
        /// Get one VerifiedTest by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Verified Test</returns>
        public Task<VerifiedTestEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Get all VerifiedTests by userId
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>collection of Verified Test</returns>
        public Task<ICollection<VerifiedTestEntity>> GetByUserIdAsync(Guid userId);

        /// <summary>
        /// Update one VerifiedTest by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedVerifiedTest">Updated Verified Test</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, VerifiedTestEntity updatedVerifiedTestEntity);

        /// <summary>
        /// Remove one VerifiedTest by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);

    }
}
