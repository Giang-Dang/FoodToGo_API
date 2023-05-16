using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class OverrideOpenHoursRepository : Repository<OverrideOpenHours>, IOverrideOpenHoursRepository
    {
        private readonly ApplicationDbContext _db;
        public OverrideOpenHoursRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<OverrideOpenHours> UpdateAsync(OverrideOpenHours overrideOpenHours)
        {
            _db.OverrideOpenHours.Update(overrideOpenHours);
            await _db.SaveChangesAsync();
            return overrideOpenHours;
        }
    }
}
