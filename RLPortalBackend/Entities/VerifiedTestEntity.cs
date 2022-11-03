using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RLPortalBackend.Entities
{
    public class VerifiedTestEntity
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid TestId { get; set; }

        public DateTimeOffset VerifyTestDateTime { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<VerifiedExerciseEntity> VerifiedAnswers { get; set; }

    }
}
