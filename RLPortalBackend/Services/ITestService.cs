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
        /// Get all tests to solve
        /// </summary>
        /// <returns>Collection of tests</returns>
        public Task<ICollection<NoRightAnswersTest>> GetAsyncAllTestsToSolve();

        /// <summary>
        /// Get one test to solve by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One test</returns>
        public Task<NoRightAnswersTest> GetAsyncTestToSolveById(Guid id);

        /// <summary>
        /// Get all tests to edit
        /// </summary>
        /// <returns>Collection of tests</returns>
        public Task<ICollection<TestDto>> GetAsyncAllTestsToEdit();

        /// <summary>
        /// Get one test to edit by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One test</returns>
        public Task<TestDto> GetAsyncTestToEditById(Guid id);

        /// <summary>
        /// Create one exercise
        /// </summary>
        /// <param name="newTest">New exercise</param>
        /// <returns></returns>
        public Task<TestDto> CreateAsync(CreateTest newTest);

        /// <summary>
        /// Update one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedTest">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, UpdateTest updatedTest);

        /// <summary>
        /// Remove one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);

        /// <summary>
        /// Checking the solved test
        /// </summary>
        /// <param name="solvedTest"></param>
        /// <returns>CompletedTestResult</returns>
        public Task<CompletedTestResult> CheckSolvedTest(SolvedTest solvedTest);
    }
}
