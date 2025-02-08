using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MoneyCaseDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMapper _mapper;
        public MoneyCasesController(IMoneyCaseService moneyCaseService, IMapper mapper)
        {
            _moneyCaseService = moneyCaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMoneyCaseList()
        {
            var values = _mapper.Map<List<ResultMoneyCaseDto>>(_moneyCaseService.TGetListAll());
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMoneyCase(UpdateMoneyCaseDto updateMoneyCaseDto)
        {
            var moneyCaseEntity = _mapper.Map<MoneyCase>(updateMoneyCaseDto);
            _moneyCaseService.TUpdate(moneyCaseEntity);
            return Ok("Para Kasası Güncellendi");
        }
    }
}