using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// SolvedTest
    /// </summary>
    public class SolvedTest
    {
        /// <summary>
        /// UserId
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// TestId
        /// </summary>
        [Required]
        public Guid TestId { get; set; }

        /// <summary>
        /// UserAnswers <see cref="SolvedExercise"/>
        /// </summary>
        [Required]
        public ICollection<SolvedExercise> UserAnswers { get; set; }
    }
}