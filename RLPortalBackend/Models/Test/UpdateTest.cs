using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Exercises <see cref="ExerciseDto"/>
        /// </summary>
        [Required]
        public ICollection<ExerciseDto> Exercises { get; set; }
    }
}
