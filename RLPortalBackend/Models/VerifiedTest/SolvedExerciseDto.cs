using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.VerifiedTest
{
    /// <summary>
    /// SolvedExercise
    /// </summary>
    public class SolvedExerciseDto
    {
        /// <summary>
        /// ExerciseId
        /// </summary>
        [Required]
        public Guid ExerciseId { get; set; }

        /// <summary>
        /// ChosenAnswer
        /// </summary>
        public string ChosenAnswer { get; set; }

    }
}
