namespace RLPortalBackend.Entities
{
    public class UserAnswerEntity
    {
        public Guid ExerciseId { get; set; }

        public string ChosenAnswer { get; set; }

        public bool IsRight { get; set; }
    }
}
