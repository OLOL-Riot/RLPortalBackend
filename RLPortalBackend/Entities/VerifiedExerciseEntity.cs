using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// VerifiedExerciseEntity
    /// </summary>
    public class VerifiedExerciseEntity
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

        /// <summary>
        /// IsRight
        /// </summary>
        [Required]
        public bool IsRight { get; set; }
    }
}
