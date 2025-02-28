using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
        public IActionResult Index()
        {
            int? menuTableID = HttpContext.Session.GetInt32("MenuTableID");

            if (menuTableID.HasValue)
            {
                ViewBag.MenuTableID = menuTableID.Value;
            }
            else
            {
                return NotFound();
            }

            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";
          
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddBasket(int ProductID)
        {
            int? menuTableID = HttpContext.Session.GetInt32("MenuTableID");

            if (!menuTableID.HasValue || ProductID <= 0)
            {
                return BadRequest("Geçersiz MenuTableID veya ProductID!");
            }

            CreateBasketDto createBasketDto = new CreateBasketDto()
            {
                ProductID = ProductID,
                MenuTableID = menuTableID.Value
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7274/api/Baskets", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Ürün sepete eklendi!", redirectUrl = "/Basket/Index" });
            }

            return Json(new { success = false, message = "Ürün eklenirken hata oluştu." });
        }
    }
}
