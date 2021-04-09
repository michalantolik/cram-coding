using CramCoding.Domain.Entities;
using CramCoding.UnitTests.AutoMapper;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Controllers;
using CramCoding.WebApp.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CramCoding.UnitTests.Controllers
{
    public class HomeControllerShould
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("  ", null)]
        [InlineData(" \t", null)]
        [InlineData("\n ", null)]
        public void DisplayPageWithLatestPostsWhenNoCategoryNameAndNoPageNumber(string categoryName, int? pageNumber)
        {
            // ARRANGE
            var automapper = AutoMapperFactory.Create();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var sut = new HomeController(automapper, postRepositoryMock);

            // ... based on data in "postRepositoryMock"
            // ... length is equal to HomeController.PageSize constant
            var expectedPosts = new[]
            {
                new Post()
                {
                    Header = "Header 5",
                    Content = "Content 5"
                },
                new Post()
                {
                    Header = "Header 4",
                    Content = "Content 4"
                }
            };

            // ACT
            var view = sut.Index(categoryName, pageNumber).Result as ViewResult;

            // ASSERT
            Assert.NotNull(view);

            var paginatedPosts = view.ViewData.Model as PaginatedList<Post>;

            Assert.NotNull(paginatedPosts);
            Assert.Equal(expectedPosts.Length, paginatedPosts.Count);

            for (int i = 0; i < paginatedPosts.Count; i++)
            {
                Assert.Equal(expectedPosts[i].Header, paginatedPosts[i].Header);
                Assert.Equal(expectedPosts[i].Content, paginatedPosts[i].Content);
            }
        }

        [Fact]
        public void DisplayRequestedPageOfPostsForGivenCategory()
        {
            // ARRANGE
            var automapper = AutoMapperFactory.Create();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var sut = new HomeController(automapper, postRepositoryMock);

            // ... based on data in "postRepositoryMock"
            var expectedPosts = new[]
            {
                new Post()
                {
                    Header = "Header 5",
                    Content = "Content 5"
                },
                new Post()
                {
                    Header = "Header 3",
                    Content = "Content 3"
                }
            };

            // ACT
            var view = sut.Index("Subcategory 6", pageNumber: 1).Result as ViewResult;

            // ASSERT
            Assert.NotNull(view);

            var paginatedPosts = view.ViewData.Model as PaginatedList<Post>;

            Assert.NotNull(paginatedPosts);
            Assert.Equal(expectedPosts.Length, paginatedPosts.Count);

            for (int i = 0; i < paginatedPosts.Count; i++)
            {
                Assert.Equal(expectedPosts[i].Header, paginatedPosts[i].Header);
                Assert.Equal(expectedPosts[i].Content, paginatedPosts[i].Content);
            }
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void DisplayPostWhenExists(int postId)
        {
            // ARRANGE
            var automapper = AutoMapperFactory.Create();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var sut = new HomeController(automapper, postRepositoryMock);

            // ... based on data in "postRepositoryMock"
            var expectedPost = new Post()
            {
                Header = $"Header {postId}",
                Content = $"Content {postId}"
            };

            // ACT
            var view = sut.Post(postId) as ViewResult;

            // ASSERT
            Assert.NotNull(view);
            var post = view.ViewData.Model as Post;

            Assert.NotNull(post);
            Assert.Equal(expectedPost.Header, post.Header);
            Assert.Equal(expectedPost.Content, post.Content);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(53)]
        [InlineData(34)]
        [InlineData(-23)]
        public void DisplayPostNotFoundPageWhenDoesNotExist(int postId)
        {
            // ARRANGE
            var automapper = AutoMapperFactory.Create();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var sut = new HomeController(automapper, postRepositoryMock);

            // ... based on data in "postRepositoryMock"
            var expectedPost = new Post()
            {
                Header = $"Header {postId}",
                Content = $"Content {postId}"
            };

            // ACT
            var view = sut.Post(postId) as ViewResult;

            // ASSERT
            Assert.NotNull(view);
            Assert.Equal("PostNotFound", view.ViewName);
        }
    }
}
