using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrderList()
        {
            var values = _mapper.Map<List<ResultOrderDto>>(_orderService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var value = _orderService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            var orderEntity = _mapper.Map<Order>(createOrderDto);
            _orderService.TAdd(orderEntity);
            return Ok("Sipariş Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveOrder(int id)
        {
            var value = _orderService.TGetByID(id);
            _orderService.TDelete(value);
            return Ok("Sipariş Silindi");
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            var orderEntity = _mapper.Map<Order>(updateOrderDto);
            _orderService.TUpdate(orderEntity);
            return Ok("Sipariş Güncellendi");
        }

        [HttpGet("GetTotalOrderCount")]
        public IActionResult GetTotalOrderCount()
        {
            var value = _orderService.TTotalOrderCount();
            return Ok(value);
        }

        [HttpGet("GetActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            var value = _orderService.TActiveOrderCount();
            return Ok(value);
        }

        [HttpGet("GetLastOrderPrice")]
        public IActionResult GetLastOrderPrice()
        {
            var value = _orderService.TLastOrderPrice();
            return Ok(value);
        }

        [HttpGet("GetTodayTotalPrice")]
        public IActionResult GetTodayTotalPrice()
        {
            var value = _orderService.TTodayTotalPrice();
            return Ok(value);
        }
    }
}