using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        private readonly SignalRContext _context;
        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
            _context = context;
        }
    }
}
