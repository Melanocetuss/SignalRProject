using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        private readonly SignalRContext _context;
        public EfSocialMediaDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatusToFalse(int id)
        {
            _context.SocialMedias.Find(id).Status = false;
            _context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            _context.SocialMedias.Find(id).Status = true;
            _context.SaveChanges();
        }
    }
}