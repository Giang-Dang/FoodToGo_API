using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IMerchantRepository : IRepository<Merchant>
    {
        Task<Merchant> UpdateAsync(Merchant merchant);
    }
}
