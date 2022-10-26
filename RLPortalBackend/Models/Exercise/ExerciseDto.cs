namespace RLPortalBackend.Models.Exercise
{
    public class ExerciseDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public ICollection<string> Answers { get; set; }

        public string RightAnswer { get; set; }
    }
}
