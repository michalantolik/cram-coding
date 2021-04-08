using AutoMapper;
using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CramCoding.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Page was set to "2" so far so that it's easier to test pagination with limited DB seed data
        // TODO: Update to bigger value which makes sense after initial stages of development
        private const int PageSize = 2;

        private readonly IMapper mapper;
        private readonly IPostRepository postRepository;

        public HomeController(
            IMapper mapper,
            IPostRepository postRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
        }

        public async Task<IActionResult> Index(string category, int? pageNumber)
        {
            IQueryable<Post> posts = null;

            // Get all posts
            if (String.IsNullOrWhiteSpace(category))
            {
                posts = this.postRepository.GetAll();
            }
            // Get posts for a given category
            else
            {
                posts = this.postRepository.GetAll()
                    .Include(p => p.Categories)
                    .Where(p => p.Categories.Any(c => c.Name == category))
                    .OrderBy(p => p.PublishedAt);
            }

            // Order by published date
            posts = posts.OrderByDescending(p => p.PublishedAt);

            // Create requested page of posts
            var viewModel = await PaginatedList<Post>.CreateAsync(posts, pageNumber ?? 1, PageSize);

            return View(viewModel);
        }
    }
}
