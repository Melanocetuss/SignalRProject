using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.TestimonialDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public TestimonialController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/Testimonials");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client = _clientFactory.CreateClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(createTestimonialDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7274/api/Testimonials", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7274/api/Testimonials?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7274/api/Testimonials/GetTestimonial?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client = _clientFactory.CreateClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(updateTestimonialDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7274/api/Testimonials", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
