using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class UserRatingRepository : Repository<UserRating>, IUserRatingRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<UserRating> UpdateAsync(UserRating userRating)
        {
            _db.UserRatings.Update(userRating);
            await _db.SaveChangesAsync();
            return userRating;
        }
    }
}
