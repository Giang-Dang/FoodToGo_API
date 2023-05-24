using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IMerchantProfileImageRepository : IRepository<MerchantProfileImage>
    {
        Task<MerchantProfileImage> UpdateAsync(MerchantProfileImage merchantProfileImage);
    }
}
