using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Repositories;
using System.Collections;

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

        private async Task<ICollection<NoRightAnswerExercise>> GetNoRightAnswerExercisesAsync(ICollection<Guid> exerciseIds)
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync(exerciseIds);
            ICollection<NoRightAnswerExercise> noRightAnswerExercises = _mapper.Map<ICollection<NoRightAnswerExercise>>(exerciseEntities);

            return noRightAnswerExercises;

        }

        public async Task<TestDto> CreateAsync(CreateTest newTest)
        {
            TestEntity newTestEntity = _mapper.Map<TestEntity>(newTest);

            IEnumerable<NewExercise> newExercises = newTest.Exercises;
            IEnumerable<ExerciseEntity> newExerciseEntities = _mapper.Map<IEnumerable<ExerciseEntity>>(newExercises);

            await _exerciseRepository.CreateManyAsync(newExerciseEntities);

            ICollection<Guid> guids = newExerciseEntities.Select(e => e.Id).ToList();
            newTestEntity.ExerciseIds = guids;

            await _testRepository.CreateAsync(newTestEntity);
            
            TestDto createdTest = _mapper.Map<TestDto>(newTestEntity);
            ICollection<ExerciseDto> createdExercise = _mapper.Map<ICollection<ExerciseDto>>(newExerciseEntities);
            createdTest.Exercises = createdExercise;

            return createdTest;
        }

        public async Task<ICollection<NoRightAnswersTest>> GetAsyncAllTestsToSolve()
        {
            ICollection<TestEntity> testEntities = await _testRepository.GetAsync();

            ICollection<NoRightAnswersTest> noRightAnswersTests = _mapper.Map<ICollection<TestEntity>, ICollection<NoRightAnswersTest>>(testEntities);

            for (int i = 0; i < testEntities.Count; i++)
            {
                TestEntity testEntity = testEntities.ElementAt(i);
                ICollection<Guid> exercisesIds = testEntity.ExerciseIds;
                ICollection<NoRightAnswerExercise> noRightAnswerExercises = await GetNoRightAnswerExercisesAsync(exercisesIds);

                NoRightAnswersTest noRightAnswersTest = noRightAnswersTests.ElementAt(i);
                noRightAnswersTest.Exercises = noRightAnswerExercises;
            }

            return noRightAnswersTests;
        }
        

        public async Task<NoRightAnswersTest> GetAsyncTestToSolveById(Guid id)
        {
            TestEntity testEntity = await _testRepository.GetAsync(id);
            NoRightAnswersTest noRightAnswersTest = _mapper.Map<NoRightAnswersTest>(testEntity);

            ICollection<Guid> exercisesIds = testEntity.ExerciseIds;
            ICollection<NoRightAnswerExercise> noRightAnswerExercises = await GetNoRightAnswerExercisesAsync(exercisesIds);
            noRightAnswersTest.Exercises = noRightAnswerExercises;

            return noRightAnswersTest;
        }

        public async Task<ICollection<TestDto>> GetAsyncAllTestsToEdit()
        {
            ICollection<TestEntity> testEntities = await _testRepository.GetAsync();

            ICollection<TestDto> testDtos = _mapper.Map<ICollection<TestEntity>, ICollection<TestDto>>(testEntities);

            for (int i = 0; i < testEntities.Count; i++)
            {
                TestEntity testEntity = testEntities.ElementAt(i);
                ICollection<Guid> exerciseIds = testEntity.ExerciseIds;
                ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync(exerciseIds);
                ICollection<ExerciseDto> exerciseDtos = _mapper.Map<ICollection<ExerciseDto>>(exerciseEntities);

                TestDto testDto = testDtos.ElementAt(i);
                testDto.Exercises = exerciseDtos;
            }

            return testDtos;
        }

        public async Task<TestDto> GetAsyncTestToEditById(Guid id)
        {
            TestEntity testEntity = await _testRepository.GetAsync(id);
            TestDto testDto = _mapper.Map<TestDto>(testEntity);

            ICollection<Guid> exercisesId = testEntity.ExerciseIds;
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync(exercisesId);
            ICollection<ExerciseDto> exerciseDtos = _mapper.Map<ICollection<ExerciseDto>>(exerciseEntities);

            testDto.Exercises = exerciseDtos;

            return testDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, UpdateTest updatedTest)
        {
            ICollection<ExerciseDto> updatedExercises = updatedTest.Exercises;
            ICollection<Guid> updatedExerciseIds = new HashSet<Guid>();

            foreach (var exerciseDto in updatedExercises)
            {
                if (exerciseDto.Id == null)
                {
                    ExerciseEntity newExerciseEntity = _mapper.Map<ExerciseEntity>(exerciseDto);
                    await _exerciseRepository.CreateAsync(newExerciseEntity);
                    updatedExerciseIds.Add(newExerciseEntity.Id);

                } else
                {
                    ExerciseEntity updatedExerciseEntity = _mapper.Map<ExerciseEntity>(exerciseDto);
                    Guid exerciseId = updatedExerciseEntity.Id;
                    await _exerciseRepository.UpdateAsync(exerciseId, updatedExerciseEntity);
                    updatedExerciseIds.Add(updatedExerciseEntity.Id);
                }
            }

            TestEntity updatedTestEntity = _mapper.Map<TestEntity>(updatedTest);
            updatedTestEntity.Id = id;
            updatedTestEntity.ExerciseIds = updatedExerciseIds;

            await _testRepository.UpdateAsync(id, updatedTestEntity);
        }
    }
}
