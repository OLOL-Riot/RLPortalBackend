namespace RLPortalBackend.Models.VerifiedTest
{
    public class UpdateVerifiedTestDto
    {
        public Guid UserId { get; set; }

        public Guid TestId { get; set; }

        public DateTimeOffset VerifyTestDateTime { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<VerifiedExerciseDto> VerifiedAnswers { get; set; }
    }
}
