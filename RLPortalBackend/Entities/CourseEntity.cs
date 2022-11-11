using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// CourseEntity
    /// </summary>
    public class CourseEntity
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
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// CourseSectionEntityIds
        /// </summary>
        public ICollection<Guid> CourseSectionEntityIds { get; set; }
    }
}
