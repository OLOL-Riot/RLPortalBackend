using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// Exercise Entity
    /// </summary>
    public class ExerciseEntity
    {

        /// <summary>
        /// Id
        /// </summary>
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        /// <summary>
        /// SerialNumber
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// Exercise description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Collection of answers
        /// </summary>
        public ICollection<string> Answers { get; set; }

        /// <summary>
        /// RightAnswer
        /// </summary>
        public string RightAnswer { get; set; }

    }
}
