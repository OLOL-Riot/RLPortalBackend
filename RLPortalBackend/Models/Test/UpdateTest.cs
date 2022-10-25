using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class UpdateTest
    {
        public string Name { get; set; }

        public ICollection<Exercise.Exercise> Exercises { get; set; }
    }
}
