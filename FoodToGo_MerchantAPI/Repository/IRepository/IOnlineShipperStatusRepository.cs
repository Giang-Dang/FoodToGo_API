using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IOnlineShipperStatusRepository : IRepository<OnlineShipperStatus>
    {
        Task<OnlineShipperStatus> UpdateAsync(OnlineShipperStatus onlineShipperStatus);
    }
}
