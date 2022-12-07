using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// NewExercise
    /// </summary>
    public class NewExerciseDto
    {
        public Guid? TestId { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Serial number
        /// </summary>
        [Required]
        public int SerialNumber { get; set; }

        /// <summary>
        /// Answers
        /// </summary>
        [Required]
        public ICollection<string> Answers { get; set; }

        /// <summary>
        /// RightAnswer
        /// </summary>
        [Required]
        public string RightAnswer { get; set; }

    }
}
