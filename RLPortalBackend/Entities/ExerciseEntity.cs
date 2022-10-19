using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// Exercise Entity
    /// </summary>
    public class ExerciseEntity
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public string Description { get; set; }

        public ICollection<string> Answers { get; set; }

        public int RightAnswer { get; set; }

    }
}
