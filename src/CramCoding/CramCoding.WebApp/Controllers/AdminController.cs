using AutoMapper;
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
        private readonly IMapper mapper;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
