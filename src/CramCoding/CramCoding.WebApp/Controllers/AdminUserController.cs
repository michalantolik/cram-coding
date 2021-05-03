using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Controller responsible for ApplicationUser administration
    /// </summary>
    public class AdminUserController : Controller
    {
        [Route("~/AdminUser/ListUsers")]
        public IActionResult ListUsers()
        {
            return View();
        }
    }
}
