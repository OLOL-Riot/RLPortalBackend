using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class SolvedTest
    {
        public Guid UserId { get; set; }

        public Guid TestId { get; set; }
        
        public ICollection<SolvedExercise> UserAnswers { get; set; }
    }
}