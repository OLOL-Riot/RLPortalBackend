﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RLPortal.Models
{
    /// <summary>
    /// Test Entity
    /// </summary>
    public class Test
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
