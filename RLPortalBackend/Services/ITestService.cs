using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Test;

namespace RLPortalBackend.Services
{
    /// <summary>
    /// Service for test
    /// </summary>
    public interface ITestService
    {
        /// <summary>
        /// Get all tests
        /// </summary>
        /// <returns>Collection of tests</returns>
        public Task<ICollection<NoRightAnswersTest>> GetAsync();

        /// <summary>
        /// Get one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One test</returns>
        public Task<NoRightAnswersTest> GetAsync(Guid id);

        /// <summary>
        /// Create one exercise
        /// </summary>
        /// <param name="newTest">New exercise</param>
        /// <returns></returns>
        public Task<Test> CreateAsync(NewTest newTest);

        /// <summary>
        /// Update one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedTest">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, NewTest updatedTest);

        /// <summary>
        /// Remove one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
