using RLPortalBackend.Models.Theory;
using RLPortalBackend.Models.VerifiedTest;

namespace RLPortalBackend.Services
{
    public interface ITheoryService
    {
        /// <summary>
        /// Create Theory
        /// </summary>
        /// <param name="theoryDto"></param>
        /// <returns></returns>
        public Task<TheoryDto> CreateAsync(NewTheoryDto theoryDto);

        /// <summary>
        /// Get all Theory
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<TheoryDto>> GetAsync();

        /// <summary>
        /// Get Theory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TheoryDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Update Theory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTheoryDto"></param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, NewTheoryDto updateTheoryDto);

        /// <summary>
        /// Remove Theory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);

    }
}
