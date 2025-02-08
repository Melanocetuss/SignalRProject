using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly SignalRContext _context;
        public EfOrderDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }

        public int ActiveOrderCount()
        {
            return _context.Orders.Count(x => x.Description == "Müşteri Masada");
        }

        public decimal LastOrderPrice()
        {
            return _context.Orders
                .OrderByDescending(x => x.OrderID)
                .Select(x => x.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            DateTime today = DateTime.Today;
            return _context.Orders
                .Where(x => x.Date >= today && x.Date < today.AddDays(1))
                .Sum(x => x.TotalPrice);
        }
    }
}