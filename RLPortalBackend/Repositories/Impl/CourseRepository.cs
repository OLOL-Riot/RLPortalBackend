using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;

namespace RLPortalBackend.Repositories.Impl
{
    public class CourseRepository: ICourseRepository
    {
        private readonly IMongoCollection<CourseSectionEntity> _courseSection;

        public CourseRepository(IOptions<PortalGeographyMongoDBSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _courseSection = mongoDatabase.GetCollection<CourseSectionEntity>(
                portalGeographyMongoDBSettings.Value.CourseCollectionName);
        }
    }
}
