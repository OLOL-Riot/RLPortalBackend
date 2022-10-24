﻿using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Services
{
    /// <summary>
    /// Service for exercise
    /// </summary>
    public interface IExerciseService
    {
        /// <summary>
        /// Get all exercises
        /// </summary>
        /// <returns>Collection of exercises</returns>
        public Task<ICollection<Exercise>> GetAsync();

        /// <summary>
        /// Get one exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>one exercise</returns>
        public Task<Exercise> GetAsync(Guid id);

        /// <summary>
        /// Create one exerci9se
        /// </summary>
        /// <param name="newExercise">New exercise</param>
        /// <returns></returns>
        public Task<Exercise> CreateAsync(NewExercise newExercise);

        /// <summary>
        /// Update one exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedExercise">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, NewExercise updatedExercise);

        /// <summary>
        /// Remove one exercise
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
