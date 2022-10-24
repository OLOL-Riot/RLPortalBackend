namespace RLPortalBackend.Dto
{
    public class TestDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ExerciseDto> Exercises { get; set; }
    }
}
