using Microsoft.AspNetCore.Mvc;
using SampleWebApiMvcClient.Models;
using SampleWebApiMvcClient.Services;
using System.Diagnostics;

namespace SampleWebApiMvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStockService _stockService;

        public HomeController(IStockService service)
        {
            _stockService = service;
        }

        public IActionResult Index()
        {
            var stocks = _stockService.GetAllStocks();
            return View(stocks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
