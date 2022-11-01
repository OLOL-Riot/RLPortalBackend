namespace RLPortalBackend.Entities
{
    public class VerifiedExerciseEntity
    {
        public Guid ExerciseId { get; set; }

        public string ChosenAnswer { get; set; }

        public bool IsRight { get; set; }
    }
}
