using RLPortalBackend.Entities;
using RLPortalBackend.Models.VerifiedTest;

namespace RLPortalBackend.Services
{
    /// <summary>
    /// Service for Verified Test
    /// </summary>
    public interface IVerifiedTestService
    {
        /// <summary>
        /// Create one VerifiedTest
        /// </summary>
        /// <param name="solvedTest">Solved test with user answers</param>
        /// <param name="username">User id</param>
        /// <returns></returns>
        public Task<VerifiedTestDto> CreateAsync(SolvedTestDto solvedTest, string username);

        /// <summary>
        /// Get all of VerifiedTests
        /// </summary>
        /// <returns>Collection of Verified Tests</returns>
        public Task<ICollection<VerifiedTestDto>> GetAsync();

        /// <summary>
        /// Get one VerifiedTest by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task<VerifiedTestDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Get all VerifiedTests by userId
        /// </summary>
        /// <param name="username">User id</param>
        /// <returns></returns>
        public Task<ICollection<VerifiedTestDto>> GetByUserIdAsync(string username);

        /// <summary>
        /// Update one VerifiedTest by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedVerifiedTest">Updated test</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, UpdateVerifiedTestDto updatedVerifiedTestDto);

        /// <summary>
        /// Remove one VerifiedTest by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
