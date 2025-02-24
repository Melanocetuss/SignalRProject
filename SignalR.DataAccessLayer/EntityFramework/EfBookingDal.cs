using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly SignalRContext _context;
        public EfBookingDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void BookingStatusApproved(int id)
        {
            _context.Bookings.Find(id).Description = "Rezervasyon Onaylandı";
            _context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            _context.Bookings.Find(id).Description = "Rezervasyon İptal Edildi";
            _context.SaveChanges();
        }
    }
}