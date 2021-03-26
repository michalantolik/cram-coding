using CramCoding.Data.Repositories;
using CramCoding.Domain.Identity;
using CramCoding.WebApp.ViewModels.Admin.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CramCoding.WebApp.Controllers
{
    [Authorize(Roles = "AdminUser")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICategoryRepository categoryRepository;
        private readonly ITagRepository tagRepository;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            this.userManager = userManager;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
        }

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
            return View(CreatePostForEdit());
        }

        [HttpPost]
        public IActionResult AddPost(EditPostViewModel post)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Posts");
            }

            return View(CreatePostForEdit());
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

        /// <summary>
        /// Creates post for edit with selection data populated from the database
        /// </summary>
        /// <returns></returns>
        private EditPostViewModel CreatePostForEdit()
        {
            return new EditPostViewModel()
            {
                Authors = this.userManager.Users
                    .Select(u => new SelectListItem(u.UserName, u.UserName)).ToArray(),
                Categories = this.categoryRepository.GetAll()
                    .Select(c => new SelectListItem(c.Name, c.Name)).ToArray(),
                Tags = this.tagRepository.GetAll()
                    .Select(t => new SelectListItem(t.Name, t.Name)).ToArray()
            };
        }
    }
}
