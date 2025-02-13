using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRContext _context;
        public EfBasketDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultBasketDto> GetBasketByMenuTableNumber(int id)
        {
            var values = _context.Baskets
                .Where(x => x.MenuTableID == id)
                .Include(x => x.Product)
                .Select(x => new ResultBasketDto
                {
                    BasketID = x.BasketID,
                    ProductID = x.ProductID,
                    ProductName = x.Product.Name,
                    ProductImageUrl = x.Product.ImageUrl,
                    Count = x.Count,
                    Price = x.Price,
                    TotalPrice = x.TotalPrice,
                    MenuTableID = x.MenuTableID,                                 
                })
                .ToList();
            return values;
        }

        public void IncreaseProductCount(int id)
        {
            var basketItem = _context.Baskets.FirstOrDefault(x => x.BasketID == id);
            
            if (basketItem != null)
            {              
                basketItem.Count += 1;
                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                _context.Baskets.Update(basketItem);
                _context.SaveChanges();
            }
        }

        public void DecreaseProductCount(int id)
        {
            var basketItem = _context.Baskets.FirstOrDefault(x => x.BasketID == id);
            
            if (basketItem != null && basketItem.Count > 1)
            {
                basketItem.Count -= 1;
                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                _context.Baskets.Update(basketItem);
                _context.SaveChanges();
            }
            else
            {
                _context.Baskets.Remove(basketItem);
                _context.SaveChanges();
            }
        }
    }
}