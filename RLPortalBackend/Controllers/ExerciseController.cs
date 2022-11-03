using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RLPortalBackend.Entities;
using RLPortalBackend.Services;
using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// Exercise controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        /// <summary>
        /// ExerciseController constructor
        /// </summary>
        /// <param name="exerciseService"></param>
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        /// <summary>
        /// Get all exercises to edit method
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<ExerciseDto>), 200)]
        [HttpGet("edit"), Authorize(Roles = "Administrator")]
        public async Task<ICollection<ExerciseDto>> GetAllExercisesToEdit()
        {
            return await _exerciseService.GetAsyncAllExercisesToEdit();
        }

        /// <summary>
        /// Get ExerciseDto by Id for edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ExerciseDto</returns>
        [HttpGet("edit/{id:length(36)}"), Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(ExerciseDto), 200)]
        public async Task<ActionResult<ExerciseDto>> GetExerciseToEditById(Guid id)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToEditById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            return exercise;
        }

        /// <summary>
        /// Get all Exercises
        /// </summary>
        /// <returns>Collection of NoRightAnswerExercise</returns>
        [HttpGet("solve"), Authorize(Roles = "User, Administrator")]
        [ProducesResponseType(typeof(ICollection<NoRightAnswerExercise>), 200)]
        public async Task<ICollection<NoRightAnswerExercise>> GetAllExercisesToSolve()
        {
            return await _exerciseService.GetAsyncAllExercisesToSolve();
        }

        /// <summary>
        /// Get NoRightAnswerExercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoRightAnswerExercise</returns>
        [HttpGet("solve/{id:length(36)}"), Authorize(Roles = "User, Administrator")]
        [ProducesResponseType(typeof(NoRightAnswerExercise), 200)]

        public async Task<ActionResult<NoRightAnswerExercise>> GetExerciseToSolveById(Guid id)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToSolveById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            return exercise;
        }

        /// <summary>
        /// Add new Exercise in MongoDB
        /// </summary>
        /// <param name="newExercise"></param>
        /// <returns>ExerciseDto with Id</returns>
        [HttpPost, Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(ExerciseDto), 201)]

        public async Task<IActionResult> Post(NewExercise newExercise)
        {
            ExerciseDto createdExercise = await _exerciseService.CreateAsync(newExercise);

            return CreatedAtAction(nameof(GetAllExercisesToEdit), new { id = createdExercise.Id }, createdExercise);
        }

        /// <summary>
        /// Update Exercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedExercise"></param>
        /// <returns></returns>
        [HttpPut("{id:length(36)}"), Authorize(Roles = "Administrator")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Update(Guid id, NewExercise updatedExercise)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToEditById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            await _exerciseService.UpdateAsync(id, updatedExercise);

            return NoContent();
        }

        /// <summary>
        /// Delete Exercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(36)}"), Authorize(Roles = "Administrator")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToEditById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            await _exerciseService.RemoveAsync(id);

            return NoContent();
        }

    }
}
