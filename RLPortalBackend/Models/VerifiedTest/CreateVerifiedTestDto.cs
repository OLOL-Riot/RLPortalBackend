namespace RLPortalBackend.Models.VerifiedTest
{
    public class CreateVerifiedTestDto
    {
        public Guid UserId { get; set; }

        public Guid TestId { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<VerifiedExerciseDto> VerifiedExercises { get; set; }

    }
}
