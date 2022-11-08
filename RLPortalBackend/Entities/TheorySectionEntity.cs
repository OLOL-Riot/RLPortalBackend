using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// Theory section entity
    /// </summary>
    public class TheorySectionEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Header
        /// </summary>
        [Required]
        public string Header { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Required]
        public string Content { get; set; }

    }
}
