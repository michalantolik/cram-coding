using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
