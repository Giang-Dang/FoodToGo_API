using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface ICustomer : IRepository<Customer>
    {
        Task<Customer> UpdateAsync(Customer customer);
    }
}