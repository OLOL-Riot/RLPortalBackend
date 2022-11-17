using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;

namespace RLPortalBackend.Repositories.Impl
{
    public class CourseSectionRepository : ICourseSectionRepository
    {

        private readonly IMongoCollection<CourseSectionEntity> _courseSection;

        public CourseSectionRepository(IOptions<PortalGeographyMongoDBSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _courseSection = mongoDatabase.GetCollection<CourseSectionEntity>(
                portalGeographyMongoDBSettings.Value.CourseSectionsCollectionName);
        }


        public async Task CreateAsync(CourseSectionEntity newCourseSectionEntity)
        {
            await _courseSection.InsertOneAsync(newCourseSectionEntity);
        }

        public async Task<ICollection<CourseSectionEntity>> GetAsync()
        {
            return await _courseSection.Find(_ => true).ToListAsync();
        }

        public async Task<CourseSectionEntity> GetAsync(Guid id)
        {
            return await _courseSection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<CourseSectionEntity>> GetAsync(ICollection<Guid> ids)
        {
            return await _courseSection.Find(el => ids.Contains(el.Id)).ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _courseSection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, CourseSectionEntity updateCourseSectionEntity)
        {
            await _courseSection.ReplaceOneAsync(x => x.Id == id, updateCourseSectionEntity);
        }
    }
}
