using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;

namespace RLPortalBackend.Repositories.Impl
{
    /// <summary>
    /// TestRepository
    /// </summary>
    public class TestRepository : ITestRepository
    {
        private readonly IMongoCollection<TestEntity> _testCollection;

        /// <summary>
        /// TestRepository connection to MongoDB
        /// </summary>
        /// <param name="portalGeographyMongoDBSettings"></param>
        public TestRepository(IOptions<MongoDbSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _testCollection = mongoDatabase.GetCollection<TestEntity>(
                portalGeographyMongoDBSettings.Value.TestCollectionName);
        }

        /// <summary>
        /// Create test in MongoDB
        /// </summary>
        /// <param name="newTest"></param>
        /// <returns></returns>
        public async Task CreateAsync(TestEntity newTest)
        {
            await _testCollection.InsertOneAsync(newTest);
        }

        /// <summary>
        /// Get all test from MongoDB
        /// </summary>
        /// <returns>Collection of test</returns>
        public async Task<ICollection<TestEntity>> GetAsync()
        {
            return await _testCollection.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Get test by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One test</returns>
        public async Task<TestEntity> GetAsync(Guid id)
        {
            return await _testCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Remove test by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid id)
        {
            await _testCollection.DeleteOneAsync(x => x.Id == id);
        }

        /// <summary>
        /// Update test by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedTest"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Guid id, TestEntity updatedTest)
        {
            await _testCollection.ReplaceOneAsync(x => x.Id == id, updatedTest);
        }
    }
}
