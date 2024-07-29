using SampleMvcFramework.Models;
using SampleMvcFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcFramework.Controllers
{
    public class StockManagerController : Controller
    {
        private readonly IStockService stockService;

        // ASP.NET MVC 5 does not come with default DI that we see in .NET Core.
        // So we use either 3rd party DI tools like Unity
        public StockManagerController()
        {
            stockService = new StockService();
        }

        // GET: StockMananger
        public ActionResult Index()
        {
            var stocks = stockService.GetAllStocks();
            return View(stocks);
        }

        public ActionResult AddNewStock()
        {
            return View(new Stock());
        }

        [HttpPost]
        public ActionResult AddNewStock(Stock postedData)
        {
            stockService.AddStock(postedData);
            return RedirectToAction("Index");
        }

        public ActionResult OnEdit(int id)
        {
            var stock = stockService.GetStock(id);
            return View(stock);
        }

        [HttpPost]
        public ActionResult OnEdit(Stock postedData)
        {
            stockService.UpdateStock(postedData);
            return RedirectToAction("Index");
        }

        public ActionResult OnDelete(int id)
        {
            var stock = stockService.GetStock(id);
            return View(stock);
        }

        [HttpPost]
        public ActionResult OnDelete(Stock postedData)
        {
            stockService.DeleteStock(postedData.Id);
            return RedirectToAction("Index");
        }
    }
}