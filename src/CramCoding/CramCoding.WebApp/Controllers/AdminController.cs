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

        public IActionResult Posts()
        {
            var postViewModels = this.postRepository.GetAll(include: true)
                .ToArray()
                .Select(p => new PostViewModel()
            {
                Header = p.Header,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                PublishedAt = p.PublishedAt,
                IsVisible = p.IsVisible,
                ViewsCount = p.ViewsCount,
                Author = p.Author.UserName,
                Categories = p.Categories.Select(c => c.Name).ToArray(),
                Tags = p.Tags.Select(t => t.Name).ToArray(),
                CommentsCount = p.Comments.Count()
            })
            .ToArray();

            return View(postViewModels);
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
