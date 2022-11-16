using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Exceptions;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        private readonly IExerciseService _exerciseService;

        public TestService(ITestRepository testRepository, IMapper mapper, IExerciseService exerciseService)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _exerciseService = exerciseService;
        }

        public async Task<TestDto> CreateAsync(CreateTestDto newTest)
        {
            TestEntity newTestEntity = _mapper.Map<TestEntity>(newTest);

            IEnumerable<NewExercise> newExercises = newTest.Exercises;
            ICollection<Guid> guids = new List<Guid>();


            foreach (NewExercise exercise in newExercises)
            {
                ExerciseDto exerciseDto = await _exerciseService.CreateAsync(exercise);
                guids.Add((Guid) exerciseDto.Id);
            }



            newTestEntity.ExerciseIds = guids;

            await _testRepository.CreateAsync(newTestEntity);

            TestDto createdTest = _mapper.Map<TestDto>(newTestEntity);
            ICollection<ExerciseDto> createdExercise = await _exerciseService.GetAsyncExercise(guids);
            createdTest.Exercises = createdExercise;

            return createdTest;
        }

        public async Task<ICollection<NoRightAnswersTestDto>> GetAsyncAllTestsToSolve()
        {
            ICollection<TestEntity> testEntities = await _testRepository.GetAsync();

            ICollection<NoRightAnswersTestDto> noRightAnswersTests = _mapper.Map<ICollection<TestEntity>, ICollection<NoRightAnswersTestDto>>(testEntities);

            for (int i = 0; i < testEntities.Count; i++)
            {
                TestEntity testEntity = testEntities.ElementAt(i);
                ICollection<Guid> exercisesIds = testEntity.ExerciseIds;

                ICollection<ExerciseDto> exerciseDtos = await _exerciseService.GetAsyncExercise(exercisesIds);
                ICollection<NoRightAnswerExercise> noRightAnswerExercises = _mapper.Map<ICollection<NoRightAnswerExercise>>(exerciseDtos);

                NoRightAnswersTestDto noRightAnswersTest = noRightAnswersTests.ElementAt(i);
                noRightAnswersTest.Exercises = noRightAnswerExercises;
            }

            return noRightAnswersTests;
        }


        public async Task<NoRightAnswersTestDto> GetAsyncTestToSolveById(Guid id)
        {
            TestEntity testEntity = await _testRepository.GetAsync(id);
            NoRightAnswersTestDto noRightAnswersTest = _mapper.Map<NoRightAnswersTestDto>(testEntity);

            if (noRightAnswersTest == null)
            {
                return noRightAnswersTest;
            }


            ICollection<Guid> exercisesIds = testEntity.ExerciseIds;

            ICollection<ExerciseDto> exerciseDtos = await _exerciseService.GetAsyncExercise(exercisesIds);
            ICollection<NoRightAnswerExercise> noRightAnswerExercises = _mapper.Map<ICollection<NoRightAnswerExercise>>(exerciseDtos);

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

                ICollection<ExerciseDto> exerciseDtos = await _exerciseService.GetAsyncExercise(exerciseIds);

                TestDto testDto = testDtos.ElementAt(i);
                testDto.Exercises = exerciseDtos;
            }

            return testDtos;
        }

        public async Task<TestDto> GetAsyncTestToEditById(Guid id)
        {
            TestEntity testEntity = await _testRepository.GetAsync(id);
            TestDto testDto = _mapper.Map<TestDto>(testEntity);

            if (testDto == null)
            {
                return testDto;
            }

            ICollection<Guid> exercisesId = testEntity.ExerciseIds;
            ICollection<ExerciseDto> exerciseDtos = await _exerciseService.GetAsyncExercise(exercisesId);
            testDto.Exercises = exerciseDtos;

            return testDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, UpdateTestDto updatedTest)
        {
            ICollection<ExerciseDto> updatedExercises = updatedTest.Exercises;
            ICollection<Guid> updatedExerciseIds = new HashSet<Guid>();

            foreach (var exerciseDto in updatedExercises)
            {
                if (exerciseDto.Id == null)
                {
                    ExerciseDto newExercise = await _exerciseService.CreateAsync(_mapper.Map<NewExercise>(exerciseDto));
                    updatedExerciseIds.Add((Guid) newExercise.Id);
                }
                else
                {
                    await _exerciseService.UpdateAsync((Guid) exerciseDto.Id, _mapper.Map<NewExercise>(exerciseDto));
                    Console.WriteLine((Guid)exerciseDto.Id);
                    updatedExerciseIds.Add((Guid) exerciseDto.Id);
                }
            }

            TestEntity updatedTestEntity = _mapper.Map<TestEntity>(updatedTest);
            updatedTestEntity.Id = id;
            updatedTestEntity.ExerciseIds = updatedExerciseIds;

            await _testRepository.UpdateAsync(id, updatedTestEntity);
        }
    }
}
