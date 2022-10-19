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

        public async Task<TestDto> CreateAsync(TestDto newTest)
        {
            TestEntity newTestEntity = _mapper.Map<TestEntity>(newTest);
            await _testRepository.CreateAsync(newTestEntity);
            newTest.Id = newTestEntity.Id;
            return newTest;
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

        public async Task UpdateAsync(Guid id, TestDto updatedTest)
        {
            TestEntity updatedTestEntity = _mapper.Map<TestEntity>(updatedTest);
            await _testRepository.UpdateAsync(id, updatedTestEntity);
        }
    }
}
