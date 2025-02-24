using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Dtos.ViewModels;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly  IHttpClientFactory _httpClientFactory;
        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // Kategoriler ve Ürünler için liste oluştur
            var categories = new List<ResultCategoryDto>();
            var products = new List<ResultProductWithCategoriesDto>();

            var productResponse = await client.GetAsync("https://localhost:7274/api/Products");
            if (productResponse.IsSuccessStatusCode)
            {
                var productJsonData = await productResponse.Content.ReadAsStringAsync();
                var allProducts = JsonConvert.DeserializeObject<List<ResultProductWithCategoriesDto>>(productJsonData);

                // Status'u "true" olan ürünleri listele
                products = allProducts.Where(p => p.Status).ToList();
            }

            var categoryResponse = await client.GetAsync("https://localhost:7274/api/Categories");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJsonData = await categoryResponse.Content.ReadAsStringAsync();
                var allCategories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);

                // Status'u "true" olan kategorileri listele
                categories = allCategories.Where(c => c.Status).ToList();
            }

            // ViewModel Oluştur ve Doldur
            var viewModel = new ProductCategoryViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(viewModel);
        }
    }
}