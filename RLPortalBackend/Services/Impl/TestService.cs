using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Test;
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

        public async Task<Test> CreateAsync(Test newTest)
        {
            TestEntity newTestEntity = _mapper.Map<TestEntity>(newTest);
            await _testRepository.CreateAsync(newTestEntity);
            newTest.Id = newTestEntity.Id;
            return newTest;
        }

        public async Task<ICollection<Test>> GetAsync()
        {
            ICollection<TestEntity> testEntities = await _testRepository.GetAsync();
            ICollection<Test> testDtos = _mapper.Map<ICollection<TestEntity>, ICollection<Test>>(testEntities);
            return testDtos;
        }

        public async Task<Test> GetAsync(Guid id)
        {
            TestEntity testEntity = await _testRepository.GetAsync(id);
            Test testDto = _mapper.Map<Test>(testEntity);
            return testDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, Test updatedTest)
        {
            TestEntity updatedTestEntity = _mapper.Map<TestEntity>(updatedTest);
            await _testRepository.UpdateAsync(id, updatedTestEntity);
        }
    }
}
