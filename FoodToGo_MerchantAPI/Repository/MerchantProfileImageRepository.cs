using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class MerchantProfileImageRepository : Repository<MerchantProfileImage>, IMerchantProfileImageRepository
    {
        private readonly ApplicationDbContext _db;
        public MerchantProfileImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<MerchantProfileImage> UpdateAsync(MerchantProfileImage merchantProfileImage)
        {
            _db.MerchantProfileImages.Update(merchantProfileImage);
            await _db.SaveChangesAsync();
            return merchantProfileImage;
        }
    }
}
