namespace RLPortalBackend.Models.Exercise
{
    public class NoRightAnswerExercise
    {
        public Guid Id { get; set; }

        public int SerialNumber { get; set; }

        public string Description { get; set; }

        public ICollection<string> Answers { get; set; }
    }
}
