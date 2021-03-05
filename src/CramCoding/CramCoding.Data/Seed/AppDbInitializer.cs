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

        public AppDbInitializer(
            RoleManager<ApplicationRole> roleManager,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository)
        {
            this.roleManager = roleManager;
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedCategoriesAsync();
            await SeedPostsAsync();
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
    }
}
