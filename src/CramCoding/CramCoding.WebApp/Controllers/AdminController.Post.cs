using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Part responsible for Post management
    /// </summary>
    public partial class AdminController
    {
        /// <summary>
        /// LISTS posts from DB
        /// </summary>
        public IActionResult Posts()
        {
            var postViewModels = this.postRepository.GetAll(include: true)
                .ToArray()
                .Select(p => new PostViewModel()
                {
                    Id = p.PostId,
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

        /// <summary>
        /// SHOWS post details for a given ID
        /// </summary>
        public IActionResult PostDetails(int id)
        {
            return View("PostDetails");
        }

        /// <summary>
        /// DISPLAYS "new post" form to be filled in
        /// </summary>
        [HttpGet]
        public IActionResult AddPost()
        {
            return View(CreatePostForEdit());
        }

        /// <summary>
        /// PERSISTS "new post" in DB
        /// </summary>
        [HttpPost]
        public IActionResult AddPost(EditPostViewModel editPostViewModel)
        {
            if (ModelState.IsValid)
            {
                var post = new Post()
                {
                    Header = editPostViewModel.Header,
                    Content = editPostViewModel.Content,
                    CreatedAt = editPostViewModel.FormSumbissionDateTimeUtc.Value, // collected automatically
                    UpdatedAt = editPostViewModel.FormSumbissionDateTimeUtc.Value, // collected automatically
                    PublishedAt = editPostViewModel.PublishedDateTimeUtc.Value,    // set by post author
                    IsVisible = editPostViewModel.IsVisible,
                    ViewsCount = 0,
                    Author = this.userManager.FindByNameAsync(editPostViewModel.SelectedAuthor).Result,

                };

                var category = this.categoryRepository.FindByName(editPostViewModel.SelectedCategory);
                if (category != null)
                {
                    post.Categories.Add(category);
                }

                foreach (var singleTag in editPostViewModel.SelectedTags)
                {
                    var tag = this.tagRepository.FindByName(singleTag);
                    if (tag != null)
                    {
                        post.Tags.Add(tag);
                    }
                }

                this.postRepository.Add(post);

                return RedirectToAction("Posts");
            }

            return View(CreatePostForEdit());
        }

        /// <summary>
        /// Creates post for edit with selection data populated from the database
        /// </summary>
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
