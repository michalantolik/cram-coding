using AutoMapper;
using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Post;
using CramCoding.WebApp.ViewModels.Home.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CramCoding.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPostRepository postRepository;

        public HomeController(
            IMapper mapper,
            IPostRepository postRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
        }

        public IActionResult Index(string category)
        {
            Post[] posts = null;
            if (String.IsNullOrWhiteSpace(category))
            {
                posts = this.postRepository.GetAll().ToArray();
            }
            else
            {
                ViewBag.SelectedCategory = category;

                posts = this.postRepository.GetAll()
                    .Include(p => p.Categories)
                    .Where(p => p.Categories.Any(c => c.Name == category))
                    .ToArray();
            }

            var viewModel = new CategoryPostsViewModel
            {
                CategoryName = category,
                Posts = posts.Select(p => this.mapper.Map<PostViewModel>(p)).ToArray()
            };

            return View(viewModel);
        }
    }
}
