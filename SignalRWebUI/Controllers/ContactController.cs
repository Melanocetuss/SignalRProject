using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public ContactController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/Contacts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var client = _clientFactory.CreateClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(createContactDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7274/api/Contacts", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> RemoveContact(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7274/api/Contacts?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7274/api/Contacts/GetContact?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var client = _clientFactory.CreateClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(updateContactDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7274/api/Contacts", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
