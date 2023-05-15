using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IMenuItemImageRepository : IRepository<MenuItemImage>
    {
        Task<MenuItemImage> UpdateAsync(MenuItemImage menuItemImage);
    }
}
