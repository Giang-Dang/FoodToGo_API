using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class OnlineShipperStatusRepository : Repository<OnlineShipperStatus>, IOnlineShipperStatusRepository
    {
        private readonly ApplicationDbContext _db;
        public OnlineShipperStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<OnlineShipperStatus> UpdateAsync(OnlineShipperStatus onlineShipperStatus)
        {
            _db.OnlineShipperStatuses.Update(onlineShipperStatus);
            await _db.SaveChangesAsync();
            return onlineShipperStatus;
        }
    }
}