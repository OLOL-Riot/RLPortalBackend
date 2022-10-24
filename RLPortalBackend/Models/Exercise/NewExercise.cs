namespace RLPortalBackend.Models.Exercise
{
    public class NewExercise
    {
        public string Description { get; set; }

        public ICollection<string> Answers { get; set; }

        public string RightAnswer { get; set; }

    }
}
