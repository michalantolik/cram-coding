using CramCoding.Data.Seed;
using CramCoding.Domain.Entities;
using CramCoding.Domain.Identity;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CramCoding.UnitTests.Seed
{
    public class AppDbInitializerShould
    {
        private AppDbInitializerMocks mocks;

        public AppDbInitializerShould()
        {
            this.mocks = new AppDbInitializerMocks();
        }

        [Fact]
        public async Task SeedRoles()
        {
            // ARRANGE
            this.mocks.RoleManagerMock.Setup(x => x.RoleExistsAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            var sut = CreateSut();

            // ACT
            await sut.SeedAsync();

            // ASSERT
            foreach (var roleName in Enum.GetNames(typeof(Role)))
            {
                this.mocks.RoleManagerMock.Verify(x => x.CreateAsync(
                    It.Is<ApplicationRole>(r => r.Name == roleName)), Times.Once);
            };
        }

        [Fact]
        public async Task SeedCategories()
        {
            // ARRANGE
            var categories = new Category[] { new Category(), new Category() };
            this.mocks.CategoryRepositoryMock.Setup(x => x.GetAll(false))
                .Returns(categories.AsQueryable());

            var sut = CreateSut();

            // ACT
            await sut.SeedAsync();

            // ASSERT
            this.mocks.CategoryRepositoryMock.Verify(x => x.Delete(
                It.IsAny<Category>()), Times.Exactly(categories.Length)
            );
            this.mocks.CategoryRepositoryMock.Verify(x => x.Add(
                It.IsAny<Category>()), Times.Exactly(2) // based on Categories.Length from CategorySeederData.cs
            );
        }

        [Fact]
        public async Task SeedTags()
        {
            // ARRANGE
            var tags = new Tag[] { new Tag(), new Tag() };
            this.mocks.TagRepositoryMock.Setup(x => x.GetAll())
                .Returns(tags.AsQueryable());

            var sut = CreateSut();

            // ACT
            await sut.SeedAsync();

            // ASSERT
            this.mocks.TagRepositoryMock.Verify(x => x.Delete(
                It.IsAny<Tag>()), Times.Exactly(tags.Length)
            );
            this.mocks.TagRepositoryMock.Verify(x => x.Add(
                It.IsAny<Tag>()), Times.Exactly(33) // based on Tags.Length from TagsSeederData.cs
            );
        }

        [Fact]
        public async Task SeedPosts()
        {
            // ARRANGE
            var posts = new Post[32];
            this.mocks.PostRepositoryMock.Setup(x => x.GetAll(false))
                .Returns(posts.AsQueryable());

            var sut = CreateSut();

            // ACT
            await sut.SeedAsync();

            // ASSERT
            this.mocks.PostRepositoryMock.Verify(x => x.Delete(
                It.IsAny<Post>()), Times.Exactly(32)
            );
            this.mocks.PostRepositoryMock.Verify(x => x.Add(
                It.IsAny<Post>()), Times.Exactly(20)
            );
        }

        private AppDbInitializer CreateSut()
        {
            return new AppDbInitializer(
                this.mocks.RoleManagerMock.Object,
                this.mocks.UserManagerMock.Object,
                this.mocks.PostRepositoryMock.Object,
                this.mocks.CategoryRepositoryMock.Object,
                this.mocks.TagRepositoryMock.Object
            );
        }
    }
}
