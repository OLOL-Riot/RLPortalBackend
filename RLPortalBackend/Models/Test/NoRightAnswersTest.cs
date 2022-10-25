using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class NoRightAnswersTest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<NoRightAnswerExercise> Exercises { get; set; }
    }
}
