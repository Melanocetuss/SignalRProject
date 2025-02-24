using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        private readonly SignalRContext _context;
        public EfDiscountDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatusToFalse(int id)
        {
            _context.Discounts.Find(id).Status = false;
            _context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            _context.Discounts.Find(id).Status = true;
            _context.SaveChanges();
        }
    }
}