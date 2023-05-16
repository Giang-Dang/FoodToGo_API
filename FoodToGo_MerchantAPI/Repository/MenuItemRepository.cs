using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<MenuItem> UpdateAsync(MenuItem menuItem)
        {
            _db.MenuItems.Update(menuItem);
            await _db.SaveChangesAsync();
            return menuItem;
        }
    }
}