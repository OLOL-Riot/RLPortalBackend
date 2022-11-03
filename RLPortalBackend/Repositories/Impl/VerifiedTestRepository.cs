using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;

namespace RLPortalBackend.Repositories.Impl
{
    public class VerifiedTestRepository : IVerifiedTestRepository
    {
        private readonly IMongoCollection<VerifiedTestEntity> _verifiedTestCollection;

        public VerifiedTestRepository(IOptions<PortalGeographyMongoDBSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _verifiedTestCollection = mongoDatabase.GetCollection<VerifiedTestEntity>(
                portalGeographyMongoDBSettings.Value.VerifiedTestCollectionName);
        }

        public async Task CreateAsync(VerifiedTestEntity newVerifiedTestEntity)
        {
            await _verifiedTestCollection.InsertOneAsync(newVerifiedTestEntity);
        }

        public async Task<ICollection<VerifiedTestEntity>> GetAsync()
        {
            return await _verifiedTestCollection.Find(_ => true).ToListAsync();
        }

        public async Task<VerifiedTestEntity> GetByIdAsync(Guid id)
        {
            return await _verifiedTestCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<VerifiedTestEntity>> GetByUserIdAsync(Guid userId)
        {
            return await _verifiedTestCollection.Find(el => userId.Equals(el.UserId)).ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _verifiedTestCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, VerifiedTestEntity updatedVerifiedTestEntity)
        {
            await _verifiedTestCollection.ReplaceOneAsync(x => x.Id == id, updatedVerifiedTestEntity);
        }
    }
}
