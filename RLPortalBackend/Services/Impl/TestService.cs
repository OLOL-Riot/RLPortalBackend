using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IExerciseRepository exerciseRepository,IMapper mapper)
        {
            _testRepository = testRepository;
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<Test> CreateAsync(NewTest newTest)
        {
            TestEntity newTestEntity = _mapper.Map<TestEntity>(newTest);

            IEnumerable<NewExercise> newExercises = newTest.Exercises;
            IEnumerable<ExerciseEntity> newExerciseEntities = _mapper.Map<IEnumerable<ExerciseEntity>>(newExercises);

            await _exerciseRepository.CreateManyAsync(newExerciseEntities);

            IEnumerable<Guid> guids = newExerciseEntities.Select(e => e.Id).ToList();
            newTestEntity.ExerciseIds = guids;

            await _testRepository.CreateAsync(newTestEntity);
            
            Test createdTest = _mapper.Map<Test>(newTestEntity);
            IEnumerable<Exercise> createdExercise = _mapper.Map<IEnumerable<Exercise>>(newExerciseEntities);
            createdTest.Exercises = createdExercise;

            return createdTest;
        }

        public async Task<ICollection<NoRightAnswersTest>> GetAsync()
        {
            ICollection<TestEntity> testEntities = await _testRepository.GetAsync();
            ICollection<NoRightAnswersTest> testDtos = _mapper.Map<ICollection<TestEntity>, ICollection<NoRightAnswersTest>>(testEntities);
            return testDtos;
        }

        public async Task<NoRightAnswersTest> GetAsync(Guid id)
        {
            TestEntity testEntity = await _testRepository.GetAsync(id);
            NoRightAnswersTest testDto = _mapper.Map<NoRightAnswersTest>(testEntity);
            return testDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, NewTest updatedTest)
        {
            TestEntity updatedTestEntity = _mapper.Map<TestEntity>(updatedTest);
            updatedTestEntity.Id = id;
            await _testRepository.UpdateAsync(id, updatedTestEntity);
        }
    }
}
