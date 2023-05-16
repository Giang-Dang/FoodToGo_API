using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class ShipperRepository : Repository<Shipper>, IShipperRepository
    {
        private readonly ApplicationDbContext _db;
        public ShipperRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Shipper> UpdateAsync(Shipper shipper)
        {
            _db.Shippers.Update(shipper);
            await _db.SaveChangesAsync();
            return shipper;
        }
    }
}