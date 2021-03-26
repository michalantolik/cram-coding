using CramCoding.Data.Repositories;
using CramCoding.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CramCoding.Data.Seed
{
    public class AppDbInitializer
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IPostRepository postRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ITagRepository tagRepository;

        public AppDbInitializer(
            RoleManager<ApplicationRole> roleManager,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            this.roleManager = roleManager;
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();

            await SeedCategoriesAsync();
            await SeedTagsAsync();
            await SeedPostsAsync();

            await AssignPostsToCategories();
            await AssignPostsToTags();
        }

        private async Task SeedRolesAsync()
        {
            foreach (var role in RolesSeederData.Data)
            {
                var roleName = role.Key.ToString();
                var roleExists = await this.roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    var applicationRole = new ApplicationRole
                    {
                        Name = roleName,
                        Description = role.Value
                    };
                    await this.roleManager.CreateAsync(applicationRole);
                }
            }
        }

        private async Task SeedCategoriesAsync()
        {
            // Delete all existing database post categories
            foreach (var category in this.categoryRepository.GetAll().ToArray())
            {
                await Task.Run(() => this.categoryRepository.Delete(category));
            }

            // Seed database post categories with seeder data
            var categorySeederData = new CategorySeederData().Categories;
            foreach (var category in categorySeederData)
            {
                await Task.Run(() => this.categoryRepository.Add(category));
            }
        }

        private async Task SeedTagsAsync()
        {
            // Delete all existing database post tags
            foreach (var tag in this.tagRepository.GetAll().ToArray())
            {
                await Task.Run(() => this.tagRepository.Delete(tag));
            }

            // Seed database post tags with seeder data
            var tagSeederData = new TagsSeederData().Tags;
            foreach (var tag in tagSeederData)
            {
                await Task.Run(() => this.tagRepository.Add(tag));
            }
        }

        private async Task SeedPostsAsync()
        {
            // Delete all existing database posts
            foreach (var post in this.postRepository.GetAll().ToArray())
            {
                await Task.Run(() => this.postRepository.Delete(post));
            }

            // Seed database posts with seeder data
            var postsSeederData = new PostsSeederData().Posts;
            foreach (var post in postsSeederData)
            {
                await Task.Run(() => this.postRepository.Add(post));
            }
        }

        private async Task AssignPostsToTags()
        {
            var tagPostsMap = new (string tagName, string[] postHeaders)[]
            {
                ("magna",
                new[]
                {
                    "Vestibulum fermentum felis dui",
                    "Nullam convallis purus in justo mattis",
                    "Praesent tempus",
                    "Lorem ipsum dolor sit amet",
                    "Suspendisse potenti",
                    "Phasellus a ultrices elit",
                    "Nullam at vehicula enim",
                    "Quisque sollicitudin risus molestie ex dapibus facilisis",
                    "Aliquam efficitur",
                    "In hac habitasse platea dictumst",
                    "Ut at sem urna",
                    "Maecenas facilisis elit nec dapibus volutpat",
                }),
                ("vestibulum",
                new[]
                {
                    "Lorem ipsum dolor sit amet",
                    "Maecenas cursus dictum leo in fringilla",
                    "Suspendisse potenti",
                    "Phasellus a ultrices elit",
                    "In hac habitasse platea dictumst",
                    "Ut at sem urna",
                    "Maecenas facilisis elit nec dapibus volutpat",
                }),
                ("primis",
                new[]
                {
                    "Morbi id posuere eros",
                    "In hac habitasse platea dictumst",
                    "Ut at sem urna",
                    "Maecenas facilisis elit nec dapibus volutpat",
                    "Nullam convallis purus in justo mattis",
                    "Praesent tempus",
                }),
                ("elementum",
                new[]
                {
                    "Cras rutrum in enim vel faucibus",
                    "Phasellus nisl elit, semper eget enim et",
                    "Phasellus a ultrices elit",
                    "Nullam at vehicula enim",
                    "In hac habitasse platea dictumst",
                    "Ut at sem urna",
                }),
            };

            await Task.Run(() =>
            {
                foreach (var tagPosts in tagPostsMap)
                {
                    foreach (var postHeader in tagPosts.postHeaders)
                    {
                        AddPostToTag(tagPosts.tagName, postHeader);
                    }
                }
            });

            void AddPostToTag(string tagName, string postHeader)
            {
                var tag = this.tagRepository.FindByName(tagName);
                var post = this.postRepository.FindByHeader(postHeader);

                if (tag != null && post != null)
                {
                    tag.Posts.Add(post);
                    this.tagRepository.Update(tag);
                }
            }
        }

        private async Task AssignPostsToCategories()
        {
            var categoryPostsMap = new (string categoryName, string[] postHeaders)[]
            {
                ("Vestibulum",
                new[]
                {
                    "Vestibulum fermentum felis dui",
                    "Nullam convallis purus in justo mattis",
                    "Praesent tempus",
                    "Lorem ipsum dolor sit amet",
                    "Suspendisse potenti",
                    "Phasellus a ultrices elit",
                    "Nullam at vehicula enim",
                    "Quisque sollicitudin risus molestie ex dapibus facilisis",
                    "Aliquam efficitur",
                    "In hac habitasse platea dictumst",
                    "Ut at sem urna",
                    "Maecenas facilisis elit nec dapibus volutpat",
                }),
                ("Lorem",
                new[]
                {
                    "Lorem ipsum dolor sit amet",
                    "Maecenas cursus dictum leo in fringilla",
                }),
                ("Morbi",
                new[]
                {
                    "Morbi id posuere eros",
                }),
                ("Proin",
                new[]
                {
                    "Proin consectetur blandit elit ut rhoncus",
                    "Vestibulum fermentum felis dui",
                    "Suspendisse id ipsum aliquam",
                }),
                ("Cras",
                new[]
                {
                    "Cras rutrum in enim vel faucibus",
                    "Phasellus nisl elit, semper eget enim et",
                }),
            };

            await Task.Run(() =>
            {
                foreach (var categoryPosts in categoryPostsMap)
                {
                    foreach (var postHeader in categoryPosts.postHeaders)
                    {
                        AddPostToCategory(categoryPosts.categoryName, postHeader);
                    }
                }
            });

            void AddPostToCategory(string categoryName, string postHeader)
            {
                var category = this.categoryRepository.FindByName(categoryName);
                var post = this.postRepository.FindByHeader(postHeader);

                if (category != null && post != null)
                {
                    category.Posts.Add(post);
                    this.categoryRepository.Update(category);
                }
            }
        }
    }
}
