using SampleMvcFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcFramework.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Hello world!";
        }

        public ViewResult Display()
        {
            var model = new Stock { Id = 123, Name = "HDFC Equity Fund", Description = "Stock investments on infrastructure", UnitPrice = 13.42235 };
            return View(model);
        }
    }
}