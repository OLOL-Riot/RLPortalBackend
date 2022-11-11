using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// TheoryEntity
    /// </summary>
    public class TheoryEntity
    {

        /// <summary>
        /// Id
        /// </summary>
        [Required]
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        [Required]
        public string ShortDescription { get; set; }

        /// <summary>
        /// TheorySectionDtos
        /// </summary>
        [Required]
        public ICollection<TheorySectionEntity> TheorySectionEntities { get; set; }
    }
}
