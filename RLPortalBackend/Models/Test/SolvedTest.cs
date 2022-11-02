using RLPortalBackend.Models.Exercise;

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
        public Guid UserId { get; set; }

        /// <summary>
        /// TestId
        /// </summary>
        public Guid TestId { get; set; }

        /// <summary>
        /// UserAnswers <see cref="SolvedExercise"/>
        /// </summary>
        public ICollection<SolvedExercise> UserAnswers { get; set; }
    }
}