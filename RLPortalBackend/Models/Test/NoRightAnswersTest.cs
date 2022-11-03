using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// NoRightAnswersTest
    /// </summary>
    public class NoRightAnswersTest
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Exercises <see cref="NoRightAnswerExercise"/>
        /// </summary>
        [Required]
        public ICollection<NoRightAnswerExercise> Exercises { get; set; }
    }
}
