using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RLPortalBackend.Entities;
using RLPortalBackend.Models;
namespace RLPortalBackend.Repositories.Impl
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IMongoCollection<ExerciseEntity> _exerciseCollection;

        public ExerciseRepository(IOptions<MongoDbSettings> portalGeographyMongoDBSettings)
        {
            var mongoClient = new MongoClient(
                portalGeographyMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                portalGeographyMongoDBSettings.Value.DatabaseName);

            _exerciseCollection = mongoDatabase.GetCollection<ExerciseEntity>(
                portalGeographyMongoDBSettings.Value.ExerciseCollectionName);
        }

        public async Task<ICollection<ExerciseEntity>> GetAsync()
        {
            return await _exerciseCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ICollection<ExerciseEntity>> GetAsync(ICollection<Guid> ids)
        {
            return await _exerciseCollection.Find(el => ids.Contains(el.Id)).ToListAsync();
        }

        public async Task<ExerciseEntity> GetAsync(Guid id)
        {
            return await _exerciseCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(ExerciseEntity newExercise)
        {
            await _exerciseCollection.InsertOneAsync(newExercise);
        }

        public async Task CreateManyAsync(IEnumerable<ExerciseEntity> exerciseEntities)
        {
            await _exerciseCollection.InsertManyAsync(exerciseEntities);
        }


        public async Task UpdateAsync(Guid id, ExerciseEntity updatedExercise)
        {
            await _exerciseCollection.ReplaceOneAsync(x => x.Id == id, updatedExercise);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _exerciseCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(ICollection<Guid> ids)
        {
            await _exerciseCollection.DeleteManyAsync(x => ids.Contains(x.Id));
        }
    }
}
