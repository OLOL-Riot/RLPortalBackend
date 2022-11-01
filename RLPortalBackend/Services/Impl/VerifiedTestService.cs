using AutoMapper;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class VerifiedTestService : IVerifiedTestService
    {
        private readonly IVerifiedTestRepository _verifiedTestRepository;
        private readonly IMapper _mapper;

        public VerifiedTestService(IVerifiedTestRepository verifiedTestRepository, IMapper mapper)
        {
            _verifiedTestRepository = verifiedTestRepository;
            _mapper = mapper;
        }

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
