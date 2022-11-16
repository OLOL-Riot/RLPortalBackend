using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// CreateTestDto
    /// </summary>
    public class CreateTestDto
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Exercises <see cref="NewExercise"/>
        /// </summary>
        [Required]
        public ICollection<NewExercise> Exercises { get; set; }
    }
}
