using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;

namespace RLPortalBackend.Repositories.Impl
{
    public class TestRepository : ITestRepository
    {
        private readonly IMongoCollection<TestEntity> _testCollection;

        public TestRepository(IOptions<PortalGeographyMongoDBSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _testCollection = mongoDatabase.GetCollection<TestEntity>(
                portalGeographyMongoDBSettings.Value.TestCollectionName);
        }

        public async Task CreateAsync(TestEntity newTest)
        {
            await _testCollection.InsertOneAsync(newTest);
        }

        public async Task<ICollection<TestEntity>> GetAsync()
        {
            return await _testCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TestEntity> GetAsync(Guid id)
        {
            return await _testCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _testCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, TestEntity updatedTest)
        {
            await _testCollection.ReplaceOneAsync(x => x.Id == id, updatedTest);
        }
    }
}
