using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IActionResult> Index()
        {
            int? menuTableID = HttpContext.Session.GetInt32("MenuTableID");
            ViewBag.MenuTableID = menuTableID.Value;
            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7274/api/Baskets?id={menuTableID.Value}");

            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> RemoveBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7274/api/Baskets?id={id}");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }

        public async Task<IActionResult> IncreaseProductCount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:7274/api/Baskets/increase/{id}",null);

            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }

        public async Task<IActionResult> DecreaseProductCount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:7274/api/Baskets/decrease/{id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }
    }
}