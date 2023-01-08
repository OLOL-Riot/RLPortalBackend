using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;

namespace RLPortalBackend.Repositories.Impl
{
    /// <summary>
    /// CourseRepository for MongoDb
    /// </summary>
    public class CourseRepository: ICourseRepository
    {
        private readonly IMongoCollection<CourseEntity> _courseCollection;

        public CourseRepository(IOptions<MongoDbSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _courseCollection = mongoDatabase.GetCollection<CourseEntity>(
                portalGeographyMongoDBSettings.Value.CourseCollectionName);
        }

        public async Task CreateAsync(CourseEntity newCourseEntity)
        {
            await _courseCollection.InsertOneAsync(newCourseEntity);
        }

        public async Task<CourseEntity> GetCourseByIdAsync(Guid id)
        {
            return await _courseCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<CourseEntity>> GetCoursesAsync()
        {
            return await _courseCollection.Find(_ => true).ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _courseCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, CourseEntity updateCourseEntity)
        {
            await _courseCollection.ReplaceOneAsync(x => x.Id == id, updateCourseEntity);
        }

        public async Task<CourseEntity> FindCourseWitchContainsCourseSEctionId(Guid id)
        {
            return await _courseCollection.Find(o => o.CourseSectionEntityIds.Contains(id)).FirstOrDefaultAsync();
        }
    }
}
