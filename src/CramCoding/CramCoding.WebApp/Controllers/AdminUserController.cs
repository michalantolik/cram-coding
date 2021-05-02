using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Controller responsible for ApplicationUser administration
    /// </summary>
    public class AdminUserController : Controller
    {
        [Route("~/AdminUser/Users")]
        public IActionResult Users()
        {
            return View();
        }
    }
}
