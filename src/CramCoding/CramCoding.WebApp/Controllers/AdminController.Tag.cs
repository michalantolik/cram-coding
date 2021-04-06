using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Tag;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Part responsible for Tag management
    /// </summary>
    public partial class AdminController
    {
        /// <summary>
        /// LISTS tags from DB
        /// </summary>
        public IActionResult Tags()
        {
            var tagViewModels = this.tagRepository.GetAll(include: true)
                .ToArray()
                .Select(tag => new TagViewModel()
                {
                    TagName = tag.Name,
                    PostsCount = tag.Posts.Count
                })
                .ToArray();

            return View(tagViewModels);
        }

        /// <summary>
        /// DISPLAYS "new tag" form to be filled in
        /// </summary>
        [HttpGet]
        public IActionResult AddTag()
        {
            return View();
        }

        /// <summary>
        /// PERSISTS "new tag" in DB
        /// </summary>
        [HttpPost]
        public IActionResult AddTag(EditTagViewModel editTagViewModel)
        {
            var alreadyExists = this.tagRepository.FindByName(editTagViewModel.TagName) != null;
            if (alreadyExists)
            {
                ModelState.AddModelError(nameof(editTagViewModel.TagName),
                    $"Tag with the name \"{editTagViewModel.TagName}\" already exists. Provide a different name.");
            }

            if (ModelState.IsValid)
            {
                var tag = this.mapper.Map<Tag>(editTagViewModel);
                this.tagRepository.Add(tag);

                return RedirectToAction("Tags");
            }

            return View();
        }
    }
}
