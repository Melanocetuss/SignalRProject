using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDetailDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        public OrderDetailsController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrderDetailList()
        {
            var values = _mapper.Map<List<ResultOrderDetailDto>>(_orderDetailService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetOrderDetail")]
        public IActionResult GetOrderDetail(int id)
        {
            var value = _orderDetailService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateOrderDetail(CreateOrderDetailDto createOrderDetailDto)
        {
            var orderDetailEntity = _mapper.Map<OrderDetail>(createOrderDetailDto);
            _orderDetailService.TAdd(orderDetailEntity);
            return Ok("Sipariş Detayı Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveOrderDetail(int id)
        {
            var value = _orderDetailService.TGetByID(id);
            _orderDetailService.TDelete(value);
            return Ok("Sipariş Detayı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
        {
            var orderDetailEntity = _mapper.Map<OrderDetail>(updateOrderDetailDto);
            _orderDetailService.TUpdate(orderDetailEntity);
            return Ok("Sipariş Detayı Güncellendi");
        }
    }
}