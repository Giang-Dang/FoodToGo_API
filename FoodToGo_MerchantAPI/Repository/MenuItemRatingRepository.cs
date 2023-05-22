using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class MenuItemRatingRepository : Repository<MenuItemRating>, IMenuItemRatingRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuItemRatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<MenuItemRating> UpdateAsync(MenuItemRating menuItemRating)
        {
            _db.MenuItemRatings.Update(menuItemRating);
            await _db.SaveChangesAsync();
            return menuItemRating;
        }
    }
}
