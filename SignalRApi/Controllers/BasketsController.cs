using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketsController(IBasketService basketService, IMapper mapper, SignalRContext context)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id) 
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBasket(CreateBasketDto createBasketDto)
        {
            _basketService.TAddBasket(createBasketDto.MenuTableID, createBasketDto.ProductID);
            return Ok("Sepete Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Sepeten Kaldırıldı");
        }

        [HttpPut("increase/{id}")]
        public IActionResult IncreaseProductCount(int id)
        {
            try
            {
                _basketService.TIncreaseProductCount(id);
                return Ok("Ürün miktarı artırıldı");
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("decrease/{id}")]
        public IActionResult DecreaseProductCount(int id)
        {
            try
            {
                _basketService.TDecreaseProductCount(id);
                return Ok("Ürün miktarı azaltıldı");
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}