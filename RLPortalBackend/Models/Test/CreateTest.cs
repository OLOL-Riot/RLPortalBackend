using RLPortalBackend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Exercises <see cref="NewExercise"/>
        /// </summary>
        [Required]
        public ICollection<NewExercise> Exercises { get; set; }
    }
}
