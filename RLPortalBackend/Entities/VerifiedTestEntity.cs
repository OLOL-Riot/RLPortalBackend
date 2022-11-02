﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RLPortalBackend.Entities
{
    public class VerifiedTestEntity
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public string Username { get; set; }

        public Guid TestId { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<VerifiedExerciseEntity> VerifiedAnswers { get; set; }

    }
}
