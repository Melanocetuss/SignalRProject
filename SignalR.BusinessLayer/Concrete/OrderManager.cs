using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order TGetByID(int id)
        {
            return _orderDal.GetByID(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public decimal TLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }
    }
}