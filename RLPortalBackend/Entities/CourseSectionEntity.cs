using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// CourseSectionEntity
    /// </summary>
    public class CourseSectionEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        [Required]
        public string ShortDescription { get; set; }

        /// <summary>
        /// SerialNumber
        /// </summary>
        [Required]
        public int SerialNumber { get; set; }

        /// <summary>
        /// TheoryEntityId
        /// </summary>
        [Required]
        public Guid TheoryEntityId { get; set; }

        /// <summary>
        /// TestEntityId
        /// </summary>
        [Required]
        public Guid TestEntityId { get; set; }

    }
}
