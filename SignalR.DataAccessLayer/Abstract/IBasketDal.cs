using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<ResultBasketDto> GetBasketByMenuTableNumber(int id);
    }
}
