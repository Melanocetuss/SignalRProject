using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext _context;
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int NotificationCountByStatusFalse()
        {
            return _context.Notifications.Count(x => x.Status == false);
        }

        public List<Notification> GetAllNotificationsByStatusFalse()
        {
            return _context.Notifications.Where(x => x.Status == false).ToList();
        }
    }
}