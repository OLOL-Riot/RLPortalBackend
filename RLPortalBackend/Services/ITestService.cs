using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.VerifiedTest;

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
        /// <returns>Collection of <see cref="NoRightAnswersTestDto"/></returns>
        public Task<ICollection<NoRightAnswersTestDto>> GetAsyncAllTestsToSolve();

        /// <summary>
        /// Get one test to solve by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns><see cref="NoRightAnswersTestDto"/></returns>
        public Task<NoRightAnswersTestDto> GetAsyncTestToSolveById(Guid id);

        /// <summary>
        /// Get all tests to edit
        /// </summary>
        /// <returns>Collection of <see cref="TestDto"/></returns>
        public Task<ICollection<TestDto>> GetAsyncAllTestsToEdit();

        /// <summary>
        /// Get one test to edit by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns><see cref="TestDto"/></returns>
        public Task<TestDto> GetAsyncTestToEditById(Guid id);

        /// <summary>
        /// Create one exercise
        /// </summary>
        /// <param name="newTest">New exercise</param>
        /// <returns><see cref="TestDto"/></returns>
        public Task<TestDto> CreateAsync(CreateTestDto newTest);

        /// <summary>
        /// Update one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedTest">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, UpdateTestDto updatedTest);

        /// <summary>
        /// Remove one test by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
