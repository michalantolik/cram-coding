using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.Domain.Identity;
using CramCoding.WebApp.ViewModels.Admin.Post;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CramCoding.WebApp.Controllers
{
    /// <summary>
    /// Part responsible for Post management
    /// </summary>
    public partial class AdminPostController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostRepository postRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ITagRepository tagRepository;

        public AdminPostController(
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

        /// <summary>
        /// LISTS posts from DB
        /// </summary>
        [Route("~/AdminPost/ListPosts")]
        public IActionResult ListPosts()
        {
            var postViewModels = this.postRepository.GetAll(include: true)
                .ToArray()
                .Select(p => new AdminPostViewModel()
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
        [Route("~/AdminPost/PostDetails/{id}")]
        public IActionResult PostDetails(int id)
        {
            var post = this.postRepository
                .GetAll(include: true)
                .FirstOrDefault(p => p.PostId == id);

            if (post == null)
            {
                //TODO: Post not found in DB. Add logging
                return new EmptyResult();
            }

            return View(post);
        }

        /// <summary>
        /// DISPLAYS "new post" form to be filled in
        /// </summary>
        [HttpGet("~/AdminPost/AddPost")]
        public IActionResult AddPost()
        {
            return View(CreatePostForEdit("AdminPost", nameof(AddPost)));
        }

        /// <summary>
        /// PERSISTS "new post" in DB
        /// </summary>
        [HttpPost("~/AdminPost/AddPost")]
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

                return RedirectToAction("ListPosts");
            }

            return View(CreatePostForEdit("AdminPost", nameof(AddPost)));
        }

        /// <summary>
        /// DISPLAYS "post" to be edited
        /// </summary>
        [HttpGet("~/AdminPost/EditPost/{id}")]
        public IActionResult EditPost(int id)
        {
            var post = this.postRepository
                .GetAll(include: true)
                .FirstOrDefault(p => p.PostId == id);

            if (post == null)
            {
                //TODO: Post not found in DB. Add logging.
                return new EmptyResult();
            }

            var editPostViewModel = CreatePostForEdit("AdminPost", nameof(EditPost));

            editPostViewModel.Header = post.Header;
            editPostViewModel.Content = post.Content;
            editPostViewModel.SelectedAuthor = post.Author.UserName;
            editPostViewModel.SelectedTags = post.Tags.Select(t => t.Name).ToArray();

            //TODO: Either allow to select multiple categories ...
            // ... or update data model so that the post is assigned only to single category
            editPostViewModel.SelectedCategory = post.Categories.FirstOrDefault().Name;

            editPostViewModel.PublishedDate = post.PublishedAt;
            editPostViewModel.PublishedTime = post.PublishedAt;
            editPostViewModel.IsVisible = post.IsVisible;

            return View(editPostViewModel);
        }

        /// <summary>
        /// PERSISTS "edited post" in DB
        /// </summary>
        [HttpPost("~/AdminPost/EditPost/{id}")]
        public IActionResult EditPost(EditPostViewModel editPostViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                var post = this.postRepository
                    .GetAll(include: true)
                    .FirstOrDefault(p => p.PostId == id);

                if (post == null)
                {
                    //TODO: Post not found in DB. Add logging.
                    return new EmptyResult();
                }

                post.Header = editPostViewModel.Header;
                post.Content = editPostViewModel.Content;
                post.CreatedAt = editPostViewModel.FormSumbissionDateTimeUtc.Value; // collected automatically
                post.UpdatedAt = editPostViewModel.FormSumbissionDateTimeUtc.Value; // collected automatically
                post.PublishedAt = editPostViewModel.PublishedDateTimeUtc.Value;    // set by post author
                post.IsVisible = editPostViewModel.IsVisible;
                post.ViewsCount = 0;
                post.Author = this.userManager.FindByNameAsync(editPostViewModel.SelectedAuthor).Result;

                var category = this.categoryRepository.FindByName(editPostViewModel.SelectedCategory);
                if (category != null && post.Categories.Contains(category) == false)
                {
                    post.Categories.Add(category);
                }

                foreach (var singleTag in editPostViewModel.SelectedTags)
                {
                    var tag = this.tagRepository.FindByName(singleTag);
                    if (tag != null && post.Tags.Contains(tag) == false)
                    {
                        post.Tags.Add(tag);
                    }
                }

                this.postRepository.Update(post);

                return RedirectToAction("ListPosts");
            }

            return View(CreatePostForEdit("AdminPost", nameof(EditPost)));
        }

        /// <summary>
        /// DELETES post from DB
        /// </summary>
        [Route("~/AdminPost/DeletePost/{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = this.postRepository.FindById(id);
            if (post == null)
            {
                //TODO: Post not found in DB. Add logging.
                return new EmptyResult();
            }

            this.postRepository.Delete(post);
            return RedirectToAction("ListPosts");
        }

        /// <summary>
        /// Creates post for edit with selection data populated from the database
        /// </summary>
        private EditPostViewModel CreatePostForEdit(string submitController, string submitAction)
        {
            return new EditPostViewModel()
            {
                SubmitController = submitController,
                SubmitAction = submitAction,
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
