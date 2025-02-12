using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<ResultBasketDto> TGetBasketByMenuTableNumber(int id);
    }
}
