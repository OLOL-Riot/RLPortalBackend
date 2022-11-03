using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// NoRightAnswerExercise
    /// </summary>
    public class NoRightAnswerExercise
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Serial number
        /// </summary>
        [Required]
        public int SerialNumber { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Answers
        /// </summary>
        [Required]
        public ICollection<string> Answers { get; set; }
    }
}
