using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IShipperRepository : IRepository<Shipper>
    {
        Task<Shipper> UpdateAsync(Shipper shipper);
    }
}
