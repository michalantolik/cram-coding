using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Part responsible for Tag management
    /// </summary>
    public partial class AdminController
    {
        public IActionResult Tags()
        {
            return View();
        }
    }
}
