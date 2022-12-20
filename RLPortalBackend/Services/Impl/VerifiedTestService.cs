using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Exceptions;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    /// <summary>
    /// VerifiedTestService
    /// </summary>
    public class VerifiedTestService : IVerifiedTestService
    {
        private readonly IVerifiedTestRepository _verifiedTestRepository;
        private readonly ITestService _testService;
        private readonly IMapper _mapper;
        private readonly IExerciseService _exerciseService;

        public VerifiedTestService(IVerifiedTestRepository verifiedTestRepository, ITestService testService, IMapper mapper, IExerciseService exerciseService)
        {
            _verifiedTestRepository = verifiedTestRepository;
            _testService = testService;
            _mapper = mapper;
            _exerciseService = exerciseService;
        }

        public async Task<VerifiedTestDto> CreateAsync(SolvedTestDto solvedTest, Guid userId)
        {
            // Add Exceptions Handling: test not found, incorrect exercises

            TestDto test = await _testService.GetAsyncTestToEditById(solvedTest.TestId);

            if(test == null)
            {
                throw new TestNotFoundException($"Test {solvedTest.TestId} not found");
            }

            ICollection<ExerciseDto> exercises = test.Exercises;

            CreateVerifiedTestDto verifiedTest = _mapper.Map<CreateVerifiedTestDto>(solvedTest);

            verifiedTest.MaxPoints = exercises.Count;
            verifiedTest.UserId = userId;

            for (int i = 0; i < verifiedTest.VerifiedAnswers.Count; i++)
            {
                VerifiedExerciseDto verifiedExercise = verifiedTest.VerifiedAnswers.ElementAtOrDefault(i);

                string rightAnswer = exercises.First(exercise => exercise.Id == verifiedExercise.ExerciseId).RightAnswer;

                var chosendAnswer = verifiedExercise.ChosenAnswer;

                verifiedExercise.IsRight = chosendAnswer == rightAnswer;
            }

            verifiedTest.Points = verifiedTest.VerifiedAnswers.Count(verifiedExercise => verifiedExercise.IsRight);
            verifiedTest.VerifyTestDateTime = DateTimeOffset.Now;

            VerifiedTestEntity verifiedTestEntity = _mapper.Map<VerifiedTestEntity>(verifiedTest);
            verifiedTestEntity.UserId = userId;

            await _verifiedTestRepository.CreateAsync(verifiedTestEntity);

            VerifiedTestDto resultVerifiedTest = _mapper.Map<VerifiedTestDto>(verifiedTest);
            resultVerifiedTest.Id = verifiedTestEntity.Id;

            return resultVerifiedTest;

        }

        public async Task<ICollection<VerifiedTestDto>> GetAsync()
        {
            ICollection<VerifiedTestEntity> verifiedTestEntities = await _verifiedTestRepository.GetAsync();
            return _mapper.Map<ICollection<VerifiedTestDto>>(verifiedTestEntities);
        }

        public async Task<VerifiedTestDto> GetByIdAsync(Guid id)
        {
            VerifiedTestEntity verifiedTestEntity = await _verifiedTestRepository.GetByIdAsync(id);
            return _mapper.Map<VerifiedTestDto>(verifiedTestEntity);
        }

        public async Task<ICollection<VerifiedTestDto>> GetByUserIdAsync(Guid userId)
        {
            ICollection<VerifiedTestEntity> verifiedTestEntities = await _verifiedTestRepository.GetByUserIdAsync(userId);
            return _mapper.Map<ICollection<VerifiedTestDto>>(verifiedTestEntities);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _verifiedTestRepository.RemoveAsync(id);
        }

        public async Task RemoveAsync(ICollection<Guid> ids)
        {
            await _verifiedTestRepository.RemoveAsyncByTestIds(ids);
        }

        public async Task UpdateAsync(Guid id, UpdateVerifiedTestDto updatedVerifiedTestDto)
        {
            VerifiedTestEntity verifiedTestEntity = _mapper.Map<VerifiedTestEntity>(updatedVerifiedTestDto);
            verifiedTestEntity.Id = id;
            await _verifiedTestRepository.UpdateAsync(id, verifiedTestEntity);
        }
    }
}
