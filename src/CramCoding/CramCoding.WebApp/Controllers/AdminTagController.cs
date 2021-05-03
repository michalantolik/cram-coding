using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Controller responsible for Tag administration
    /// </summary>
    [Authorize(Roles = "AdminUser")]
    public class AdminTagController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        /// <summary>
        /// LISTS tags from DB
        /// </summary>
        [Route("~/AdminTag/ListTags")]
        public IActionResult ListTags()
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
        [HttpGet("~/AdminTag/AddTag")]
        public IActionResult AddTag()
        {
            return View();
        }

        /// <summary>
        /// PERSISTS "new tag" in DB
        /// </summary>
        [HttpPost("~/AdminTag/AddTag")]
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
                var tag = new Tag()
                {
                    Name = editTagViewModel.TagName
                };
                this.tagRepository.Add(tag);

                return RedirectToAction("ListTags");
            }

            return View();
        }
    }
}
