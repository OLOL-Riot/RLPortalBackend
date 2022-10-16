using AutoMapper;
using RLPortalBackend.Dto;
using RLPortalBackend.Entities;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(TestDto newExercise)
        {
            TestEntity newTestEntity = _mapper.Map<TestEntity>(newExercise);
            await _testRepository.CreateAsync(newTestEntity);
        }

        public async Task<ICollection<TestDto>> GetAsync()
        {
            ICollection<TestEntity> testEntities = await _testRepository.GetAsync();
            ICollection<TestDto> testDtos = _mapper.Map<ICollection<TestEntity>, ICollection<TestDto>>(testEntities);
            return testDtos;
        }

        public async Task<TestDto> GetAsync(Guid id)
        {
            TestEntity testEntity = await _testRepository.GetAsync(id);
            TestDto testDto = _mapper.Map<TestDto>(testEntity);
            return testDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, TestDto updatedExercise)
        {
            TestEntity updatedTestEntity = _mapper.Map<TestEntity>(updatedExercise);
            await _testRepository.UpdateAsync(id, updatedTestEntity);
        }
    }
}
