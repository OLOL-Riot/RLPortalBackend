using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class TestDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Exercise.ExerciseDto> Exercises { get; set; }
    }
}
