namespace RLPortalBackend.Models.VerifiedTest
{
    public class UserAnswerDto
    {
        public Guid ExerciseId { get; set; }

        public string ChosenAnswer { get; set; }

        public bool IsRight { get; set; }
    }
}
