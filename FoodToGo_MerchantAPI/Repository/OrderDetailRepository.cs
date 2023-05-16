using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;

namespace FoodToGo_API.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<OrderDetail> UpdateAsync(OrderDetail orderDetail)
        {
            _db.OrderDetails.Update(orderDetail);
            await _db.SaveChangesAsync();
            return orderDetail;
        }
    }
}