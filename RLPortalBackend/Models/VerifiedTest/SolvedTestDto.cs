namespace RLPortalBackend.Models.VerifiedTest
{
    public class SolvedTestDto
    {
        public string Username { get; set; }

        public Guid TestId { get; set; }

        public ICollection<SolvedExercise> UserAnswers { get; set; }
    }
}