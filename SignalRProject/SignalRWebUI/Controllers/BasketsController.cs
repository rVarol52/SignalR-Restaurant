﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7228/api/Basket/BasketListByMenuTableWithProductName?id=4");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }

            return View();
        } 

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesseage = await client.DeleteAsync($"https://localhost:7228/api/Basket/{id}");
            if (responseMesseage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
        

    }
}
