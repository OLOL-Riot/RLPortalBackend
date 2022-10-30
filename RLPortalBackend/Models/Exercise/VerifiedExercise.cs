namespace RLPortalBackend.Models.Exercise
{
    public class VerifiedExercise
    {
        public Guid Id { get; set; }

        public string RightAnswer { get; set; }

        public bool IsRight { get; set; }
    }
}