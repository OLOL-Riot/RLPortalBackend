using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class NewTest
    {
        public string Name { get; set; }

        public ICollection<NewExercise> Exercises { get; set; }
    }
}
