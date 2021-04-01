using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Part responsible for User management
    /// </summary>
    public partial class AdminController
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
