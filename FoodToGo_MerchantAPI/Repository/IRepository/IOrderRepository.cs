using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> UpdateAsync(Order order);
    }
}
