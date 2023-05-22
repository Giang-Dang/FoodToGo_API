using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IMenuItemRatingRepository : IRepository<MenuItemRating>
    {
        Task<MenuItemRating> UpdateAsync(MenuItemRating menuItemRating);
    }
}
