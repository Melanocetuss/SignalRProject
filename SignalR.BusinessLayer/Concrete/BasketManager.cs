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

        public Basket TGetByID(int id)
        {
            return _basketDal.GetByID(id);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public void TIncreaseProductCount(int id)
        {
            _basketDal.IncreaseProductCount(id);
        }

        public void TDecreaseProductCount(int id)
        {
            _basketDal.DecreaseProductCount(id);
        }

        // suanlik bunlar kullanilmiyor
        public void TAdd(Basket entity)
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