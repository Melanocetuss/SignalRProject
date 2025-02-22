using Microsoft.AspNetCore.SignalR;
using SignalR.EntityLayer.Entities;
using System.Globalization;
using System.Text.Json;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private static int clientCount = 0;
        public async Task SendStatistics()
        {
            var client = _httpClientFactory.CreateClient();

            #region Category Count
            var categoryCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Categories/CategoryCount");
            var categoryCount = await categoryCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
            #endregion

            #region Active Category Count
            var activeCategoryCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Categories/ActiveCategoryCount");
            var activeCategoryCount = await activeCategoryCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);
            #endregion

            #region Passive Category Count
            var passiveCategoryCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Categories/PassiveCategoryCount");
            var passiveCategoryCount = await passiveCategoryCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);
            #endregion

            #region Product Count
            var productCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Products/ProductCount");
            var productCount = await productCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
            #endregion

            #region Product Count By CategoryName Hamburger
            var productCountByCategoryNameHamburgerResponseMessage = await client.GetAsync("https://localhost:7274/api/Products/ProductCountByCategoryNameHamburger");
            var productCountByCategoryNameHamburger = await productCountByCategoryNameHamburgerResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByCategoryNameHamburger);
            #endregion

            #region Product Count By CategoryName Drink
            var productCountByCategoryNameDrinkResponseMessage = await client.GetAsync("https://localhost:7274/api/Products/ProductCountByCategoryNameDrink");
            var productCountByCategoryNameDrink = await productCountByCategoryNameDrinkResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);
            #endregion

            #region Product Average Price
            var productAveragePriceResponseMessage = await client.GetAsync("https://localhost:7274/api/Products/ProductAveragePrice");
            var productAveragePrice = await productAveragePriceResponseMessage.Content.ReadAsStringAsync();

            // String'i decimal'e çevir
            if (decimal.TryParse(productAveragePrice, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                // 2 ondalık basamak ile formatla ve gönder
                await Clients.All.SendAsync("ReceiveProductAveragePrice",
                    price.ToString("N2", new CultureInfo("tr-TR")) + " ₺");
            }
            else
            {
                await Clients.All.SendAsync("ReceiveProductAveragePrice", "Geçersiz fiyat");
            }
            #endregion

            #region Product Name Max Price
            var productNameMaxPriceResponseMessage = await client.GetAsync("https://localhost:7274/api/Products/ProductNameMaxPrice");
            var productNameMaxPrice = await productNameMaxPriceResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveProductNameMaxPrice", productNameMaxPrice);
            #endregion

            #region Product Name Min Price
            var productNameMinPriceResponseMessage = await client.GetAsync("https://localhost:7274/api/Products/ProductNameMinPrice");
            var productNameMinPrice = await productNameMinPriceResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveProductNameMinPrice", productNameMinPrice);
            #endregion

            #region Product Average Price By CategoryName Hamburger
            var productAveragePriceByCategoryNameHamburgerResponseMessage =
                await client.GetAsync("https://localhost:7274/api/Products/ProductAveragePriceByCategoryNameHamburger");

            var productAveragePriceByCategoryNameHamburger =
                await productAveragePriceByCategoryNameHamburgerResponseMessage.Content.ReadAsStringAsync();

            // String'i decimal'e çevir
            if (decimal.TryParse(productAveragePriceByCategoryNameHamburger, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price2))
            {
                // 2 ondalık basamak ile formatla ve gönder
                await Clients.All.SendAsync("ReceiveProductAveragePriceByCategoryNameHamburger",
                    price.ToString("N2", new CultureInfo("tr-TR")) + " ₺");
            }
            else
            {
                await Clients.All.SendAsync("ReceiveProductAveragePriceByCategoryNameHamburger", "Geçersiz fiyat");
            }
            #endregion

            #region Total Order Count
            var totalOrderCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Orders/GetTotalOrderCount");
            var totalOrderCount = await totalOrderCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);
            #endregion

            #region Active Order Count
            var activeOrderCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Orders/GetActiveOrderCount");
            var activeOrderCount = await activeOrderCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);
            #endregion

            #region Last Order Price
            var lastOrderPriceResponseMessage = await client.GetAsync("https://localhost:7274/api/Orders/GetLastOrderPrice");
            var lastOrderPrice = await lastOrderPriceResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice);
            #endregion

            #region Money Case Total Amount
            var moneyCaseTotalAmountResponseMessage = await client.GetAsync("https://localhost:7274/api/MoneyCases");

            if (moneyCaseTotalAmountResponseMessage.IsSuccessStatusCode)
            {
                var moneyCaseJson = await moneyCaseTotalAmountResponseMessage.Content.ReadAsStringAsync();
                var moneyCases = JsonSerializer.Deserialize<List<MoneyCase>>(moneyCaseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Toplam miktarı al
                var totalAmount = moneyCases?.FirstOrDefault()?.TotalAmount ?? 0;

                // Sadece totalAmount değerini gönder
                await Clients.All.SendAsync("ReceiveMoneyCaseTotalAmount", totalAmount.ToString("0,00") + " ₺");
            }
            #endregion

            #region Today Total Price
            var todayTotalPriceResponseMessage = await client.GetAsync("https://localhost:7274/api/Orders/GetTodayTotalPrice");
            var todayTotalPrice = await todayTotalPriceResponseMessage.Content.ReadAsStringAsync();

            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice + " ₺");         
            #endregion

            #region Menu Table Count
            var menuTableCountResponseMessage = await client.GetAsync("https://localhost:7274/api/MenuTables/GetMenuTableByStatusFalseCount");
            var menuTableCount = await menuTableCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);
            #endregion

            #region Proggress Bar Money Case
            var proggressBarMoneyCaseTotalAmountResponseMessage = await client.GetAsync("https://localhost:7274/api/MoneyCases");

            if (proggressBarMoneyCaseTotalAmountResponseMessage.IsSuccessStatusCode)
            {
                var proggressBarMoneyCaseJson = await proggressBarMoneyCaseTotalAmountResponseMessage.Content.ReadAsStringAsync();
                var proggressBarMoneyCases = JsonSerializer.Deserialize<List<MoneyCase>>(proggressBarMoneyCaseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Toplam miktarı al
                var totalAmount = proggressBarMoneyCases?.FirstOrDefault()?.TotalAmount ?? 0;

                // Sadece totalAmount değerini gönder
                await Clients.All.SendAsync("ReceiveProggressBarMoneyCaseTotalAmount", totalAmount.ToString("0,00" + " ₺"));
            }
            #endregion           

            #region Porggress Bar Active Order Count
            var proggressBarActiveOrderCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Orders/GetActiveOrderCount");
            var proggressBarActiveOrderCount = await proggressBarActiveOrderCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveProggressBarActiveOrderCount", proggressBarActiveOrderCount);
            #endregion

            #region Proggress Bar Menu Table Count
            var proggressBarMenuTableCountResponseMessage = await client.GetAsync("https://localhost:7274/api/MenuTables/GetMenuTableByStatusFalseCount");
            var proggressBarMenuTableCount = await proggressBarMenuTableCountResponseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveProggressBarMenuTableCount", proggressBarMenuTableCount);
            #endregion
        }

        public async Task SendBookingList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/Bookings");           
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                await Clients.All.SendAsync("ReceiveBookingList", jsonData);
            }
        }

        public async Task SendNotification()
        {
            var client = _httpClientFactory.CreateClient();

            #region NotificationCountByStatusFalse
            var NotificationCountResponseMessage = await client.GetAsync("https://localhost:7274/api/Notifications/NotificationCountByStatusFalse");
            if (NotificationCountResponseMessage.IsSuccessStatusCode)
            {
                var NotificationCountJsonData = await NotificationCountResponseMessage.Content.ReadAsStringAsync();
                var notificationCount = int.Parse(NotificationCountJsonData);
                await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", notificationCount);
            }
            #endregion

            #region NotificationListByStatusFalse
            var NotificationListByStatusFalseResponseMessage = await client.GetAsync("https://localhost:7274/api/Notifications/GetAllNotificationsByStatusFalse");
            if (NotificationListByStatusFalseResponseMessage.IsSuccessStatusCode)
            {
                var NotificationListByStatusFalseJsonData = await NotificationListByStatusFalseResponseMessage.Content.ReadAsStringAsync();
                await Clients.All.SendAsync("ReceiveNotificationListByStatusFalse", NotificationListByStatusFalseJsonData);
            }
            #endregion
        }

        public async Task SendMenuTable()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/MenuTables");

            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                await Clients.All.SendAsync("ReceiveMenuTableList", jsonData);
            }
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}