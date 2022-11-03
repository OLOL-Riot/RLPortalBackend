using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// VerifiedTestEntity
    /// </summary>
    public class VerifiedTestEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        [BsonId(IdGenerator = typeof(GuidGenerator))]
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
        public ICollection<VerifiedExerciseEntity> VerifiedAnswers { get; set; }

    }
}
