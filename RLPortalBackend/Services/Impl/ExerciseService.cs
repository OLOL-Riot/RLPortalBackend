using AutoMapper;
using RLPortalBackend.Dto;
using RLPortalBackend.Entities;
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

        public async Task<ExerciseDto> CreateAsync(ExerciseDto newExercise)
        {
            ExerciseEntity newExerciseEntity = _mapper.Map<ExerciseEntity>(newExercise);
            await _exerciseRepository.CreateAsync(newExerciseEntity);
            newExercise.Id = newExerciseEntity.Id;
            return newExercise;
        }

        public async Task<ICollection<ExerciseDto>> GetAsync()
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync();
            ICollection<ExerciseDto> exerciseDtos = _mapper.Map<ICollection<ExerciseEntity>, ICollection<ExerciseDto>>(exerciseEntities);
            return exerciseDtos;
        }

        public async Task<ExerciseDto> GetAsync(Guid id)
        {
            ExerciseEntity exerciseEntity = await _exerciseRepository.GetAsync(id);
            ExerciseDto exerciseDto = _mapper.Map<ExerciseDto>(exerciseEntity);
            return exerciseDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _exerciseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, ExerciseDto updatedExercise)
        {
            ExerciseEntity updatedExerciseEntity = _mapper.Map<ExerciseEntity>(updatedExercise);
            await _exerciseRepository.UpdateAsync(id, updatedExerciseEntity);
        }
    }
}
