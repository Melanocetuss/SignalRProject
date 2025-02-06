using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext _context;
        public EfCategoryDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int CategoryCount()
        {
            return _context.Categories.Count();
        }

        public int ActiveCategoryCount()
        {
            return _context.Categories.Count(x => x.Status == true);
        }

        public int PassiveCategoryCount()
        {
            return _context.Categories.Count(x => x.Status == false);
        }
    }
}