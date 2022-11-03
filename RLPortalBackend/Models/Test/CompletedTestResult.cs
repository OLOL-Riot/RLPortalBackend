using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int Points { get; set; }

        /// <summary>
        /// MaxPoints
        /// </summary>
        [Required]
        public int MaxPoints { get; set; }

        /// <summary>
        /// VerifiedAnswers <see cref="VerifiedExercise"/>
        /// </summary>
        [Required]
        public ICollection<VerifiedExercise> VerifiedAnswers { get; set; }
    }
}