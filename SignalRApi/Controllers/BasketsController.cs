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
        public BasketsController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketBtMenuTableID(int id) 
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
           _basketService.TAdd(new Basket
           {
               ProductID = createBasketDto.ProductID,
               Count = 1,
               MenuTableID = 2,
               Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(x => x.Price).FirstOrDefault(),
               TotalPrice = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(x => x.Price).FirstOrDefault()
           });
           return Ok("Sepete Eklendi");
        }
    }
}
