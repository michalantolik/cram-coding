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
                    CategoryId = category.CategoryId,
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
            var editCategoryViewModel = new EditCategoryViewModel()
            {
                SubmitController = "Admin",
                SubmitAction = nameof(AddCategory)
            };

            return View(editCategoryViewModel);
        }

        /// <summary>
        /// PERSISTS "new category" in DB
        /// </summary>
        [HttpPost("~/Admin/AddCategory")]
        public IActionResult AddCategory(EditCategoryViewModel editCategoryViewModel)
        {
            editCategoryViewModel.SubmitController = "Admin";
            editCategoryViewModel.SubmitAction = nameof(AddCategory);

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

            return View(editCategoryViewModel);
        }

        /// <summary>
        /// DISPLAYS category to be edited
        /// </summary>
        [HttpGet("~/Admin/EditCategory/{id}")]
        public IActionResult EditCategory(int id)
        {
            var category = this.categoryRepository
                .GetAll(include: true)
                .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                //TODO: Category not found in DB. Add logging
                return new EmptyResult();
            }

            var editCategoryViewModel = new EditCategoryViewModel()
            {
                CategoryName = category.Name,
                SubmitController = "Admin",
                SubmitAction = nameof(EditCategory)
            };

            return View(editCategoryViewModel);
        }

        /// <summary>
        /// PERSISTS edited category in DB
        /// </summary>
        [HttpPost("~/Admin/EditCategory/{id}")]
        public IActionResult EditCategory(EditCategoryViewModel editCategoryViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                var category = this.categoryRepository
                    .GetAll(include: true)
                    .FirstOrDefault(c => c.CategoryId == id);

                if (category == null)
                {
                    //TODO: Category not found in DB. Add logging.
                    return new EmptyResult();
                }

                category.Name = editCategoryViewModel.CategoryName;

                this.categoryRepository.Update(category);

                return RedirectToAction("Categories");
            }

            return View(editCategoryViewModel);
        }
    }
}
