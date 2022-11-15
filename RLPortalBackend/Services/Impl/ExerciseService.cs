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
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<ExerciseDto> CreateAsync(NewExercise newExercise)
        {
            ExerciseEntity newExerciseEntity = _mapper.Map<ExerciseEntity>(newExercise);
            await _exerciseRepository.CreateAsync(newExerciseEntity);
            ExerciseDto createdExercise = _mapper.Map<ExerciseDto>(newExerciseEntity);
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

        public async Task<ICollection<NoRightAnswerExercise>> GetAsyncAllExercisesToSolve()
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync();
            ICollection<NoRightAnswerExercise> noRightAnswerExercises = _mapper.Map<ICollection<NoRightAnswerExercise>>(exerciseEntities);
            return noRightAnswerExercises;
        }

        public async Task<NoRightAnswerExercise> GetAsyncExerciseToSolveById(Guid id)
        {
            ExerciseEntity exerciseEntity = await _exerciseRepository.GetAsync(id);
            NoRightAnswerExercise noRightAnswerExercises = _mapper.Map<NoRightAnswerExercise>(exerciseEntity);
            return noRightAnswerExercises;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _exerciseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, NewExercise updatedExercise)
        {
            ExerciseEntity updatedExerciseEntity = _mapper.Map<ExerciseEntity>(updatedExercise);
            updatedExerciseEntity.Id = id;
            await _exerciseRepository.UpdateAsync(id, updatedExerciseEntity);
        }
    }
}
