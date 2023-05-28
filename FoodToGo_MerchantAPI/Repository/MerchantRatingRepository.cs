using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class MerchantRatingRepository : Repository<MerchantRating>, IMerchantRatingRepository
    {
        private readonly ApplicationDbContext _db;
        public MerchantRatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<MerchantRating> UpdateAsync(MerchantRating merchantRating)
        {
            _db.MerchantRatings.Update(merchantRating);
            await _db.SaveChangesAsync();
            return merchantRating;
        }
    }
}
