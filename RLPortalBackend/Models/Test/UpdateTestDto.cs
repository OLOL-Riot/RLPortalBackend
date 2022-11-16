using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// UpdateTestDto
    /// </summary>
    public class UpdateTestDto
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
