using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Exercises <see cref="ExerciseDto"/>
        /// </summary>
        [Required]
        public ICollection<ExerciseDto> Exercises { get; set; }
    }
}
