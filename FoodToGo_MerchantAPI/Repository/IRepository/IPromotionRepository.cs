using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        Task<Promotion> UpdateAsync(Promotion promotion);
    }
}
