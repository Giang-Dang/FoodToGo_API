using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class OnlineCustomerLocationRepository : Repository<OnlineCustomerLocation>, IOnlineCustomerLocationRepository
    {
        private readonly ApplicationDbContext _db;
        public OnlineCustomerLocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<OnlineCustomerLocation> UpdateAsync(OnlineCustomerLocation onlineCustomerLocation)
        {
            _db.OnlineCustomerLocations.Update(onlineCustomerLocation);
            await _db.SaveChangesAsync();
            return onlineCustomerLocation;
        }
    }
}