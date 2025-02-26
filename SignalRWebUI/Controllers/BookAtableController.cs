using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ApiValidationError;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BookAtableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookAtableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7274/api/Bookings", stringContent);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }
}