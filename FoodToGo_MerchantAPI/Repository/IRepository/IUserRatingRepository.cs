using FoodToGo_API.Models.DbEntities;

namespace FoodToGo_API.Repository.IRepository
{
    public interface IUserRatingRepository : IRepository<UserRating>
    {
        Task<UserRating> UpdateAsync(UserRating userRating);
    }
}
