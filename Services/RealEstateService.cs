using RealEstateAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RealEstateAPI.Services
{
    public class RealEstateService
    {
        private readonly IMongoCollection<RealEstate> _realEstateCollection;

        public RealEstateService(IOptions<RealEstateDatabaseSettings> realEstateDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                    realEstateDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
                    realEstateDatabaseSettings.Value.DatabaseName);
            _realEstateCollection = mongoDatabase.GetCollection<RealEstate>(
                realEstateDatabaseSettings.Value.RealEstateCollectionName);
        }

        public async Task<List<RealEstate>> GetAsync() =>
        await _realEstateCollection.Find(_ => true).ToListAsync();

        public async Task<RealEstate?> GetAsync(string id) =>
            await _realEstateCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RealEstate newRealEstate) =>
            await _realEstateCollection.InsertOneAsync(newRealEstate);

        public async Task UpdateAsync(string id, RealEstate updatedRealEstate) =>
            await _realEstateCollection.ReplaceOneAsync(x => x.Id == id, updatedRealEstate);

        public async Task RemoveAsync(string id) =>
            await _realEstateCollection.DeleteOneAsync(x => x.Id == id);
    }
}