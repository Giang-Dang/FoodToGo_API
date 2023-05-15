using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IOnlineCustomerLocationRepository : IRepository<OnlineCustomerLocation>
    {
        Task<OnlineCustomerLocation> UpdateAsync(OnlineCustomerLocation onlineCustomerLocation);
    }
}
