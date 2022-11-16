using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.VerifiedTest
{
    /// <summary>
    /// VerifiedExerciseDto
    /// </summary>
    public class VerifiedExerciseDto
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

        /// <summary>
        /// IsRight
        /// </summary>
        [Required]
        public bool IsRight { get; set; }
    }
}
