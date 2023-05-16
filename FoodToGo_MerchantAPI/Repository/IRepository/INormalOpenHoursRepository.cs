using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface INormalOpenHoursRepository : IRepository<NormalOpenHours>
    {
        Task<NormalOpenHours> UpdateAsync(NormalOpenHours normalOpenHours);
    }
}
