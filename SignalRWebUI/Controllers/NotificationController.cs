using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.NotificationDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/Notifications");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7274/api/Notifications", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> RemoveNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7274/api/Notifications?id={id}");

            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7274/api/Notifications/GetNotification?id={id}");
            
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
            StringContent stringContent = new StringContent(jsonData);
            var responseMessage = await client.PutAsync("https://localhost:7274/api/Notifications", stringContent);
            
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> NotificationStatusChangeTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:7274/api/Notifications/NotificationStatusChangeToTrue?id={id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }

        public async Task<IActionResult> NotificationStatusChangeFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:7274/api/Notifications/NotificationStatusChangeToFalse?id={id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }
    }
}
