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
        private readonly SignalRContext _context;
        public BasketsController(IBasketService basketService, IMapper mapper, SignalRContext context)
        {
            _basketService = basketService;
            _mapper = mapper;
            _context = context;
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
            // Ürünün mevcut fiyatını al
            var productPrice = _context.Products
                .Where(x => x.ProductID == createBasketDto.ProductID)
                .Select(x => x.Price)
                .FirstOrDefault();

            // Sepette bu ürün var mı
            var existingBasketItem = _context.Baskets
                .FirstOrDefault(x => x.ProductID == createBasketDto.ProductID && x.MenuTableID == 2);

            if (existingBasketItem != null)
            {
                // Ürün zaten sepette varsa
                existingBasketItem.Count += 1;
                existingBasketItem.TotalPrice = existingBasketItem.Count * existingBasketItem.Price;

                _context.Baskets.Update(existingBasketItem);
            }

            // Ürün sepette yoksa
            else
            {
                
                var newBasketItem = new Basket
                {
                    ProductID = createBasketDto.ProductID,
                    Count = 1,
                    MenuTableID = 2,
                    Price = productPrice,
                    TotalPrice = productPrice
                };

                _context.Baskets.Add(newBasketItem);
            }

            _context.SaveChanges();
            return Ok("Sepete Eklendi");
        }
    }
}