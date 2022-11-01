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
        /// <summary>
        /// Id
        /// </summary>
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of Execise Id
        /// </summary>
        public ICollection<Guid> ExerciseIds { get; set; }
    }
}
