using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Exceptions;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper, ITestRepository testRepository)
        {
            _testRepository = testRepository;
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<ExerciseDto> CreateAsync(NewExerciseDto newExercise)
        {
            ExerciseEntity newExerciseEntity = _mapper.Map<ExerciseEntity>(newExercise);
            await _exerciseRepository.CreateAsync(newExerciseEntity);
            ExerciseDto createdExercise = _mapper.Map<ExerciseDto>(newExerciseEntity);
            if(!newExercise.TestId.Equals(null)) {
                TestEntity testEntity = await _testRepository.GetAsync((Guid) newExercise.TestId);
                testEntity.ExerciseIds.Add((Guid)createdExercise.Id);
                await _testRepository.UpdateAsync(testEntity.Id, testEntity);

            }


            return createdExercise;
        }

        public async Task<ICollection<ExerciseDto>> GetAsyncAllExercisesToEdit()
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync();
            ICollection<ExerciseDto> exerciseDtos = _mapper.Map<ICollection<ExerciseDto>>(exerciseEntities);
            return exerciseDtos;
        }

        public async Task<ExerciseDto> GetAsyncExerciseToEditById(Guid id)
        {
            ExerciseEntity exerciseEntity = await _exerciseRepository.GetAsync(id);
            if (exerciseEntity == null)
            {
                throw new ExerciseNotFoundException($"Exercise {id} not found");
            }
            ExerciseDto exerciseDto = _mapper.Map<ExerciseDto>(exerciseEntity);
            return exerciseDto;
        }

        public async Task<ICollection<NoRightAnswerExerciseDto>> GetAsyncAllExercisesToSolve()
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync();
            ICollection<NoRightAnswerExerciseDto> noRightAnswerExercises = _mapper.Map<ICollection<NoRightAnswerExerciseDto>>(exerciseEntities);
            return noRightAnswerExercises;
        }

        public async Task<NoRightAnswerExerciseDto> GetAsyncExerciseToSolveById(Guid id)
        {
            if (await _exerciseRepository.GetAsync(id) == null)
            {
                throw new NotFoundException($"Exercise {id} not found");
            }
            ExerciseEntity exerciseEntity = await _exerciseRepository.GetAsync(id);
            NoRightAnswerExerciseDto noRightAnswerExercises = _mapper.Map<NoRightAnswerExerciseDto>(exerciseEntity);
            return noRightAnswerExercises;
        }

        public async Task RemoveAsync(Guid id)
        {
            if (await _exerciseRepository.GetAsync(id) == null)
            {
                throw new NotFoundException($"Exercise {id} not found");
            }
            await _exerciseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, NewExerciseDto updatedExercise)
        {
            if (await _exerciseRepository.GetAsync(id) == null)
            {
                throw new NotFoundException($"Exercise {id} not found");
            }
            ExerciseEntity updatedExerciseEntity = _mapper.Map<ExerciseEntity>(updatedExercise);
            updatedExerciseEntity.Id = id;
            await _exerciseRepository.UpdateAsync(id, updatedExerciseEntity);
        }

        public async Task<ICollection<ExerciseDto>> GetAsyncExercise(ICollection<Guid> guids)
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync(guids);
            ICollection<ExerciseDto> exerciseDtos = _mapper.Map<ICollection<ExerciseDto>>(exerciseEntities);
            return exerciseDtos; 
        }
    }
}
