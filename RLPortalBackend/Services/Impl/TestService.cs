using RLPortalBackend.Entities;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task CreateAsync(TestEntity newExercise)
        {
            await _testRepository.CreateAsync(newExercise);
        }

        public async Task<ICollection<TestEntity>> GetAsync()
        {
            return await _testRepository.GetAsync();
        }

        public async Task<TestEntity> GetAsync(Guid id)
        {
            return await GetAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, TestEntity updatedExercise)
        {
            await _testRepository.UpdateAsync(id, updatedExercise);
        }
    }
}
