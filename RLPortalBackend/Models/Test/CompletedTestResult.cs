using RLPortalBackend.Models.Exercise;
using System.Text.Json.Serialization;

namespace RLPortalBackend.Models.Test
{
    public class CompletedTestResult
    {
        [JsonPropertyName("Points")]
        public int Points { get; set; }

        [JsonPropertyName("MaxPoints")]
        public int MaxPoints { get; set; }

        public ICollection<VerifiedExercise> VerifiedAnswers { get; set; }
    }
}