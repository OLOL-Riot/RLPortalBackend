using RLPortalBackend.Models.VerifiedTest;

namespace RLPortalBackend.Services.Impl
{
    public class VerifiedTestService : IVerifiedTestService
    {
        public Task CreateAsync(SolvedTestDto solvedTest, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<VerifiedTestDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VerifiedTestDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<VerifiedTestDto>> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, VerifiedTestDto updatedVerifiedTestDto)
        {
            throw new NotImplementedException();
        }
    }
}
