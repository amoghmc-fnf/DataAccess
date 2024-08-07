﻿using Microsoft.AspNetCore.Mvc;

namespace SampleMvcWebApp.Controllers
{
    public class TraversingController : Controller
    {
        public IActionResult Index()
        {
            var options = new string[] { "Add", "Subtract", "Multiply", "Divide" };
            ViewData["options"] = options;
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formCollection)
        {
            var options = new string[] { "Add", "Subtract", "Multiply", "Divide" };
            ViewData["options"] = options;
            var first = double.Parse(formCollection["firstValue"]);
            var second = double.Parse(formCollection["secondValue"]);
            var option = formCollection["slOptions"];
            var result = 0.0;

            switch (option)
            {
                case "Add": result = first + second; break;
                case "Subtract": result = first - second; break;
                case "Multiply": result = first * second; break;
                case "Divide": result = first / second; break;
                default: break;
            }

            ViewBag.Result = result;
            return View();
        }
    }
}
