using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// UpdateTest
    /// </summary>
    public class UpdateTest
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Exercises
        /// </summary>
        public ICollection<ExerciseDto> Exercises { get; set; }
    }
}
