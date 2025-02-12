using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;
        public BasketManager(IBasketDal basketDal)
        {
           _basketDal = basketDal;
        }
        public List<ResultBasketDto> TGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }
        
        // suanlik bunlar kullanilmiyor
        public void TAdd(Basket entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public Basket TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}