using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IOverrideOpenHoursRepository : IRepository<OverrideOpenHours>
    {
        Task<OverrideOpenHours> UpdateAsync(OverrideOpenHours overrideOpenHours);
    }
}
