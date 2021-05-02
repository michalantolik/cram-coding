using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Controller responsible for Comment administration
    /// </summary>
    [Authorize(Roles = "AdminUser")]
    public class AdminCommentController : Controller
    {
        [Route("~/AdminComment/Comments")]
        public IActionResult Comments()
        {
            return View();
        }
    }
}
