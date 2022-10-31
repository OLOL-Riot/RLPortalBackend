using RLPortalBackend.Models.Exercise;
using System.Text.Json.Serialization;

namespace RLPortalBackend.Models.Test
{
    public class CompletedTestResult
    {
        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<VerifiedExercise> VerifiedAnswers { get; set; }
    }
}