using RLPortalBackend.Models.Theory;
using RLPortalBackend.Models.VerifiedTest;

namespace RLPortalBackend.Services
{
    public interface ITheoryService
    {
        public Task<TheoryDto> CreateAsync(NoIdTheoryDto theoryDto);

        public Task<ICollection<TheoryDto>> GetAsync();

        public Task<TheoryDto> GetByIdAsync(Guid id);

        public Task UpdateAsync(Guid id, NoIdTheoryDto updateTheoryDto);

        public Task RemoveAsync(Guid id);

    }
}
