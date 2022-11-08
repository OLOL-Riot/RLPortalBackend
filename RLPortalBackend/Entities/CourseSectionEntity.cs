using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    public class CourseSectionEntity
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public ICollection<Guid> TheoryEntityId { get; set; }

        [Required]
        public ICollection<Guid> TestEntityId { get; set; }

    }
}
