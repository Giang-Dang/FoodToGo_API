using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class MerchantRepository : Repository<Merchant>, IMerchantRepository
    {
        private readonly ApplicationDbContext _db;
        public MerchantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Merchant> UpdateAsync(Merchant merchant)
        {
            _db.Merchants.Update(merchant);
            await _db.SaveChangesAsync();
            return merchant;
        }
    }
}
