using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// Exercise Entity
    /// </summary>
    public class ExerciseEntity
    {

        /// <summary>
        /// Id
        /// </summary>
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// SerialNumber
        /// </summary>
        [Required]
        public int SerialNumber { get; set; }

        /// <summary>
        /// Exercise description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Collection of answers
        /// </summary>
        [Required]
        public ICollection<string> Answers { get; set; }

        /// <summary>
        /// RightAnswer
        /// </summary>
        [Required]
        public string RightAnswer { get; set; }

    }
}
