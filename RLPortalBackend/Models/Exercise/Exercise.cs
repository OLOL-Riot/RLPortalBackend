namespace RLPortalBackend.Models.Exercise
{
    public class Exercise
    {
        public Guid? Id { get; set; }

        public string Description { get; set; }

        public ICollection<string> Answers { get; set; }
    }
}
