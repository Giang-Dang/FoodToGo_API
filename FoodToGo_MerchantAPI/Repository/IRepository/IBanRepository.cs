using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IBanRepository : IRepository<Ban>
    {
        Task<Ban> UpdateAsync(Ban ban);
    }
}
