using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// CreateTest
    /// </summary>
    public class CreateTest
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Exercises
        /// </summary>
        public ICollection<NewExercise> Exercises { get; set; }
    }
}
