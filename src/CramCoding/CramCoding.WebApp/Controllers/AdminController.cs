using CramCoding.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    [Authorize(Roles = "AdminUser")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(EditPostViewModel post)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Posts");
            }

            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Tags()
        {
            return View();
        }

        public IActionResult Comments()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
