using Microsoft.AspNetCore.Mvc;

namespace MovieMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
