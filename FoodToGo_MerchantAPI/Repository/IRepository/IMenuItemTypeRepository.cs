using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IMenuItemTypeRepository : IRepository<MenuItemType>
    {
        Task<MenuItemType> UpdateAsync(MenuItemType menuItemType);
    }
}
