using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        private readonly ApplicationDbContext _db;
        public PromotionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Promotion> UpdateAsync(Promotion promotion)
        {
            _db.Promotions.Update(promotion);
            await _db.SaveChangesAsync();
            return promotion;
        }
    }
}
