using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        Task<MenuItem> UpdateAsync(MenuItem menuItem);
    }
}
