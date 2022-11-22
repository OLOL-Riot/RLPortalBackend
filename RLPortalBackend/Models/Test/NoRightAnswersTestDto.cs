using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// NoRightAnswersTestDto
    /// </summary>
    public class NoRightAnswersTestDto
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
        /// Exercises <see cref="NoRightAnswerExerciseDto"/>
        /// </summary>
        [Required]
        public ICollection<NoRightAnswerExerciseDto> Exercises { get; set; }
    }
}
