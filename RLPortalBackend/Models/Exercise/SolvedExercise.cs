using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// SolvedExercise
    /// </summary>
    public class SolvedExercise
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// ChosenAnswer
        /// </summary>
        [Required]
        public string ChosenAnswer { get; set; }

    }
}
