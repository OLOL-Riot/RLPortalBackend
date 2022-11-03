using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.VerifiedTest
{
    /// <summary>
    /// SolvedExercise
    /// </summary>
    public class SolvedExercise
    {
        /// <summary>
        /// ExerciseId
        /// </summary>
        [Required]
        public Guid ExerciseId { get; set; }

        /// <summary>
        /// ChosenAnswer
        /// </summary>
        [Required]
        public string ChosenAnswer { get; set; }

    }
}
