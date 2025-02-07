using AutoMapper;
using SignalR.DtoLayer.OrderDetailDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class OrderDetailMapping : Profile
    {
        public OrderDetailMapping() 
        {
            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailDto>().ReverseMap();
        }
    }
}