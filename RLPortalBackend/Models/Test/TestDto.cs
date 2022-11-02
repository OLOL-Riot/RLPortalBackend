using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// TestDto
    /// </summary>
    public class TestDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Exercises <see cref="ExerciseDto"/>
        /// </summary>
        public ICollection<ExerciseDto> Exercises { get; set; }
    }
}
