namespace RLPortalBackend.Dto
{
    public class TestDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Guid?> ExerciseIds { get; set; }
    }
}
