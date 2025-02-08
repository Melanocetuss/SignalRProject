using AutoMapper;
using SignalR.DtoLayer.MoneyCaseDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MoneyCaseMapping : Profile
    {
        public MoneyCaseMapping()
        {
            CreateMap<MoneyCase, ResultMoneyCaseDto>().ReverseMap();
            CreateMap<MoneyCase, UpdateMoneyCaseDto>().ReverseMap();
        }
    }
}