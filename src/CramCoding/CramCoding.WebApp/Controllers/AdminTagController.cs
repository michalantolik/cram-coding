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
                    TagId = tag.TagId,
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
            var editTagViewModel = new EditTagViewModel()
            {
                SubmitController = "AdminTag",
                SubmitAction = nameof(AddTag)
            };

            return View(editTagViewModel);
        }

        /// <summary>
        /// PERSISTS "new tag" in DB
        /// </summary>
        [HttpPost("~/AdminTag/AddTag")]
        public IActionResult AddTag(EditTagViewModel editTagViewModel)
        {
            editTagViewModel.SubmitAction = "AdminTag";
            editTagViewModel.SubmitController = nameof(AddTag);

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

        /// <summary>
        /// DISPLAYS tag to be edited
        /// </summary>
        [HttpGet("~/AdminTag/EditTag/{id}")]
        public IActionResult EditTag(int id)
        {
            var tag = this.tagRepository
                .GetAll(include: true)
                .FirstOrDefault(t => t.TagId == id);

            if (tag == null)
            {
                //TODO: Tag not found in DB. Add logging
                return new EmptyResult();
            }

            var editTagViewModel = new EditTagViewModel()
            {
                TagName = tag.Name,
                SubmitController = "AdminTag",
                SubmitAction = nameof(EditTag)
            };

            return View(editTagViewModel);
        }

        /// <summary>
        /// PERSISTS edited tag in DB
        /// </summary>
        [HttpPost("~/AdminTag/EditTag/{id}")]
        public IActionResult EditTag(EditTagViewModel editTagViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                var tag = this.tagRepository
                    .GetAll(include: true)
                    .FirstOrDefault(t => t.TagId == id);

                if (tag == null)
                {
                    //TODO: Tag not found in DB. Add logging.
                    return new EmptyResult();
                }

                tag.Name = editTagViewModel.TagName;

                this.tagRepository.Update(tag);

                return RedirectToAction("ListTags");
            }

            return View(editTagViewModel);
        }
    }
}
