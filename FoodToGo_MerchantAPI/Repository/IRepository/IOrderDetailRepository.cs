using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        Task<OrderDetail> UpdateAsync(OrderDetail orderDetail);
    }
}
