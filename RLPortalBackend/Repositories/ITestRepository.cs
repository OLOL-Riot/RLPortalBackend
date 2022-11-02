using RLPortalBackend.Entities;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// The repository with tests
    /// </summary>
    public interface ITestRepository
    {
        /// <summary>
        /// Get all of tests
        /// </summary>
        /// <returns>Collection of <see cref="TestEntity"/></returns>
        public Task<ICollection<TestEntity>> GetAsync();

        /// <summary>
        /// Get one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns><see cref="TestEntity"/></returns>
        public Task<TestEntity> GetAsync(Guid id);

        /// <summary>
        /// Create one test
        /// </summary>
        /// <param name="newTest">New test</param>
        /// <returns></returns>
        public Task CreateAsync(TestEntity newTest);

        /// <summary>
        /// Update one test by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedTest">Updated test</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, TestEntity updatedTest);

        /// <summary>
        /// Remove one test by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
