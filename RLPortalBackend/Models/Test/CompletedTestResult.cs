using RLPortalBackend.Models.Exercise;
using System.Text.Json.Serialization;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// CompletedTestResult
    /// </summary>
    public class CompletedTestResult
    {
        /// <summary>
        /// Points
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// MaxPoints
        /// </summary>
        public int MaxPoints { get; set; }

        /// <summary>
        /// VerifiedAnswers
        /// </summary>
        public ICollection<VerifiedExercise> VerifiedAnswers { get; set; }
    }
}