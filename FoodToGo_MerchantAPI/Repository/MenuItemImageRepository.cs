using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class MenuItemImageRepository : Repository<MenuItemImage>, IMenuItemImageRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuItemImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<MenuItemImage> UpdateAsync(MenuItemImage menuItemImage)
        {
            _db.MenuItemImages.Update(menuItemImage);
            await _db.SaveChangesAsync();
            return menuItemImage;
        }
    }
}
