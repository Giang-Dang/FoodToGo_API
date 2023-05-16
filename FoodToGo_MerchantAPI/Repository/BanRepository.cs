using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class BanRepository : Repository<Ban>, IBanRepository
    {
        private readonly ApplicationDbContext _db;
        public BanRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Ban> UpdateAsync(Ban ban)
        {
            _db.Bans.Update(ban);
            await _db.SaveChangesAsync();
            return ban;
        }
    }
}