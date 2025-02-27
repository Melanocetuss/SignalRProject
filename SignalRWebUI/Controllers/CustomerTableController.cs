﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MenuTableDtos;
using System.Net.Http;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CustomerTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CustomerTableList()
        {
            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/MenuTables");
            
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
