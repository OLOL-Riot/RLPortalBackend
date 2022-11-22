using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;

namespace RLPortalBackend.Repositories.Impl
{
    public class TheoryRepository : ITheoryRepository
    {
        private readonly IMongoCollection<TheoryEntity> _theoryCollection;

        public TheoryRepository(IOptions<MongoDbSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _theoryCollection = mongoDatabase.GetCollection<TheoryEntity>(
                portalGeographyMongoDBSettings.Value.TheoryCollectionName);
        }

        public async Task CreateAsync(TheoryEntity newTheory)
        {
            await _theoryCollection.InsertOneAsync(newTheory);
        }

        public async Task<ICollection<TheoryEntity>> GetAsync()
        {
            return await _theoryCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TheoryEntity> GetAsync(Guid id)
        {
            return await _theoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _theoryCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, TheoryEntity updatedTheory)
        {
            await _theoryCollection.ReplaceOneAsync(x => x.Id == id, updatedTheory);
        }

        public async Task CreateManyAsync(IEnumerable<TheoryEntity> theoryEntities)
        {
            await _theoryCollection.InsertManyAsync(theoryEntities);
        }
    }
}
