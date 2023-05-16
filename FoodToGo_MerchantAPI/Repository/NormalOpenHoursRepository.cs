using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class NormalOpenHoursRepository : Repository<NormalOpenHours>, INormalOpenHoursRepository
    {
        private readonly ApplicationDbContext _db;
        public NormalOpenHoursRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<NormalOpenHours> UpdateAsync(NormalOpenHours normalOpenHours)
        {
            _db.NormalOpenHours.Update(normalOpenHours);
            await _db.SaveChangesAsync();
            return normalOpenHours;
        }
    }
}
