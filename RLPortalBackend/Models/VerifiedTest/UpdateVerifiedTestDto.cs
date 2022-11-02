namespace RLPortalBackend.Models.VerifiedTest
{
    public class UpdateVerifiedTestDto
    {
        public string Username { get; set; }

        public Guid TestId { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<VerifiedExerciseDto> UserAnswers { get; set; }
    }
}
