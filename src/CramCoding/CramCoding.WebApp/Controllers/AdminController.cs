using CramCoding.Data.Repositories;
using CramCoding.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Controllers
{
    [Authorize(Roles = "AdminUser")]
    public partial class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostRepository postRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ITagRepository tagRepository;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            this.userManager = userManager;
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
