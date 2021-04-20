using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Part responsible for Comment management
    /// </summary>
    public partial class AdminController
    {
        [Route("~/Admin/Comments")]
        public IActionResult Comments()
        {
            return View();
        }
    }
}
