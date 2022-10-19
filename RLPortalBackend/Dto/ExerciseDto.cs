namespace RLPortalBackend.Dto
{
    public class ExerciseDto
    {
        public Guid? Id { get; set; }

        public string Description { get; set; }

        public ICollection<string> Answers { get; set; }

        public int RightAnswer { get; set; }
    }
}
