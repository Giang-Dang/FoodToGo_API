using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IMerchantRatingRepository : IRepository<MerchantRating>
    {
        Task<MerchantRating> UpdateAsync(MerchantRating merchantRating);
    }
}
