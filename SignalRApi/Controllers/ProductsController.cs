using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var productEntity = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(productEntity);
            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var productEntity = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(productEntity);
            return Ok("Ürün Güncellendi");
        }

        [HttpGet("GetProductWithCategories")]
        public IActionResult GetProductWithCategories()
        {
            var value = _mapper.Map<List<ResultProductWithCategoriesDto>>(_productService.TGetProductWithCategories());
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }

        [HttpGet("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductAveragePrice")]
        public IActionResult ProductAveragePrice()
        {
            return Ok(_productService.TProductAveragePrice());
        }

        [HttpGet("ProductNameMaxPrice")]
        public IActionResult ProductMaxPrice()
        {
            return Ok(_productService.TProductNameMaxPrice());
        }

        [HttpGet("ProductNameMinPrice")]
        public IActionResult ProductMinPrice()
        {
            return Ok(_productService.TProductNameMinPrice());
        }

        [HttpGet("ProductAveragePriceByCategoryNameHamburger")]
        public IActionResult ProductPrice() 
        {
            return Ok(_productService.TProductAveragePriceByCategoryNameHamburger());
        }
    }
}