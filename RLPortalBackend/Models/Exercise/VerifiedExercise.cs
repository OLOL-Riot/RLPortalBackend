using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// VerifiedExercise
    /// </summary>
    public class VerifiedExercise
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Right answer
        /// </summary>
        [Required]
        public string RightAnswer { get; set; }

        /// <summary>
        /// IsRight
        /// </summary>
        [Required]
        public bool IsRight { get; set; }
    }
}