using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        void AddBasket(int MenuTableID, int ProductID);
        List<ResultBasketDto> GetBasketByMenuTableNumber(int id);
        void IncreaseProductCount(int id);
        void DecreaseProductCount(int id);
    }
}
