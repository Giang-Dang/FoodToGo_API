using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class MenuItemTypeRepository : Repository<MenuItemType>, IMenuItemTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuItemTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<MenuItemType> UpdateAsync(MenuItemType menuItemType)
        {
            _db.MenuItemTypes.Update(menuItemType);
            await _db.SaveChangesAsync();
            return menuItemType;
        }
    }
}