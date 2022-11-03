using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.VerifiedTest
{
    /// <summary>
    /// SolvedTestDto
    /// </summary>
    public class SolvedTestDto
    {
        /// <summary>
        /// TestId
        /// </summary>
        [Required]
        public Guid TestId { get; set; }

        /// <summary>
        /// UserAnswers
        /// </summary>
        [Required]
        public ICollection<SolvedExercise> UserAnswers { get; set; }
    }
}