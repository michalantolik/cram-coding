using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Category;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Part responsible for Category management
    /// </summary>
    public partial class AdminController
    {
        /// <summary>
        /// LISTS categories from DB
        /// </summary>
        [Route("~/Admin/Categories")]
        public IActionResult Categories()
        {
            var categoryViewModels = this.categoryRepository.GetAll(include: true)
                .ToArray()
                .Select(category => new CategoryViewModel()
                {
                    CategoryName = category.Name,
                    PostsCount = category.Posts.Count
                })
                .ToArray();

            return View(categoryViewModels);
        }

        /// <summary>
        /// DISPLAYS "new category" form to be filled in
        /// </summary>
        [HttpGet("~/Admin/AddCategory")]
        public IActionResult AddCategory()
        {
            return View();
        }

        /// <summary>
        /// PERSISTS "new category" in DB
        /// </summary>
        [HttpPost("~/Admin/AddCategory")]
        public IActionResult AddCategory(EditCategoryViewModel editCategoryViewModel)
        {
            var alreadyExists = this.categoryRepository.FindByName(editCategoryViewModel.CategoryName) != null;
            if (alreadyExists)
            {
                ModelState.AddModelError(nameof(editCategoryViewModel.CategoryName),
                    $"Category with the name \"{editCategoryViewModel.CategoryName}\" already exists. Provide a different name.");
            }

            if (ModelState.IsValid)
            {
                var category = this.mapper.Map<Category>(editCategoryViewModel);
                this.categoryRepository.Add(category);

                return RedirectToAction("Categories");
            }

            return View();
        }
    }
}
