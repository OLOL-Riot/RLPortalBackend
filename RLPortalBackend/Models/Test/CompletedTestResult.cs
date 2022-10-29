using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class CompletedTestResult
    {
        public int Points;

        public int MaxPoints;

        public ICollection<VerifiedExercise> VerifiedAnswers;
    }
}