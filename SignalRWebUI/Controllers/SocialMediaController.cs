﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public SocialMediaController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/SocialMedias");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7274/api/SocialMedias", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7274/api/SocialMedias?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7274/api/SocialMedias/GetSocialMedia?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7274/api/SocialMedias", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:7274/api/SocialMedias/ChangeStatusToTrue?id={id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:7274/api/SocialMedias/ChangeStatusToFalse?id={id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }
    }
}
