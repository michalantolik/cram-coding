using CramCoding.UnitTests.AutoMapper;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Controllers;
using CramCoding.WebApp.ViewModels.Admin.Post;
using CramCoding.WebApp.ViewModels.Home.Post;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Controllers
{
    public class HomeControllerShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(" \t")]
        [InlineData("\n ")]
        public void IndexAllPostsWhenCategoryNameNullOrWhitespace(string categoryName)
        {
            // ARRANGE
            var automapper = AutoMapperFactory.Create();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var sut = new HomeController(automapper, postRepositoryMock);

            // ... based on data in "postRepositoryMock"
            var expectedPosts = new[]
            {
                new HomePostViewModel()
                {
                    Header = "Header 1",
                    Content = "Content 1"
                },
                new HomePostViewModel()
                {
                    Header = "Header 3",
                    Content = "Content 3"
                },
                new HomePostViewModel()
                {
                    Header = "Header 4",
                    Content = "Content 4"
                },
                new HomePostViewModel()
                {
                    Header = "Header 2",
                    Content = "Content 2"
                },
                new HomePostViewModel()
                {
                    Header = "Header 5",
                    Content = "Content 5"
                },
            };

            // ACT
            var view = sut.Index(categoryName) as ViewResult;

            // ASSERT
            Assert.NotNull(view);

            var viewModel = view.ViewData.Model as CategoryPostsViewModel;
            Assert.NotNull(viewModel);

            Assert.Equal(categoryName, viewModel.CategoryName);

            var actualPosts = viewModel.Posts.ToArray();
            Assert.Equal(expectedPosts.Length, actualPosts.Length);

            for (int i = 0; i < actualPosts.Length; i++)
            {
                Assert.Equal(expectedPosts[i].Header, actualPosts[i].Header);
                Assert.Equal(expectedPosts[i].Content, actualPosts[i].Content);
            }
        }

        [Fact]
        public void IndexCategoryPostsWhenFilteredByCategoryName()
        {
            // ARRANGE
            var automapper = AutoMapperFactory.Create();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var sut = new HomeController(automapper, postRepositoryMock);

            // ... based on data in "postRepositoryMock"
            var expectedPosts = new[]
            {
                new AdminPostViewModel()
                {
                    Header = "Header 3",
                    Content = "Content 3"
                },
                new AdminPostViewModel()
                {
                    Header = "Header 5",
                    Content = "Content 5"
                }
            };

            // ACT
            var view = sut.Index("Subcategory 6") as ViewResult;

            // ASSERT
            Assert.NotNull(view);

            var viewModel = view.ViewData.Model as CategoryPostsViewModel;
            Assert.NotNull(viewModel);

            Assert.Equal("Subcategory 6", viewModel.CategoryName);

            var actualPosts = viewModel.Posts.ToArray();
            Assert.Equal(expectedPosts.Length, actualPosts.Length);

            for (int i = 0; i < actualPosts.Length; i++)
            {
                Assert.Equal(expectedPosts[i].Header, actualPosts[i].Header);
                Assert.Equal(expectedPosts[i].Content, actualPosts[i].Content);
            }
        }
    }
}
