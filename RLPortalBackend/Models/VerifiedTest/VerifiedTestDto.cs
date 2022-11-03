using RLPortalBackend.Entities;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.VerifiedTest
{
    /// <summary>
    /// VerifiedTestDto
    /// </summary>
    public class VerifiedTestDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// TestId
        /// </summary>
        [Required]
        public Guid TestId { get; set; }

        /// <summary>
        /// VerifyTestDateTime
        /// </summary>
        [Required]
        public DateTimeOffset VerifyTestDateTime { get; set; }

        /// <summary>
        /// Points
        /// </summary>
        [Required]
        public int Points { get; set; }

        /// <summary>
        /// MaxPoints
        /// </summary>
        [Required]
        public int MaxPoints { get; set; }

        /// <summary>
        /// VerifiedAnswers
        /// </summary>
        [Required]
        public ICollection<VerifiedExerciseDto> VerifiedAnswers { get; set; }
    }
}
