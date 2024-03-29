﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Main administration controller
    /// </summary>
    [Authorize(Roles = "AdminUser")]
    public partial class AdminController : Controller
    {
        [Route("~/Admin")]
        [Route("~/Admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
