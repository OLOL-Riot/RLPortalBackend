using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations.Schema;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// Test Entity
    /// </summary>
    public class TestEntity
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Guid> ExerciseIds { get; set; }
    }
}
