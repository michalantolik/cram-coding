using CramCoding.Domain.Identity;
using CramCoding.UnitTests.AutoMapper;
using CramCoding.UnitTests.Identity;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Controllers;
using CramCoding.WebApp.ViewModels.Admin.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CramCoding.UnitTests.Controllers
{
    public partial class AdminControllerShould
    {
        [Fact]
        public void ReturnCurrentFormViewWhenAddingInvalidPost()
        {
            // ARRANGE
            var userManagerMock = IdentityMocksFactory.CreateUserManagerMock();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var categoryRepositoryMock = new RepositoryMocks().CategoryRepositoryMock;
            var tagRepositoryMock = new RepositoryMocks().TagRepositoryMock;
            var automapper = AutoMapperFactory.Create();

            var sut = new AdminController(
                userManagerMock.Object,
                postRepositoryMock,
                categoryRepositoryMock,
                tagRepositoryMock,
                automapper
            );

            sut.ModelState.AddModelError("firstName", "Invalid First Name");

            // ACT
            var post = new EditPostViewModel();
            var result = sut.AddPost(post);

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void RedirectToPostsWhenAddingValidPost()
        {
            // ARRANGE
            var userManagerMock = IdentityMocksFactory.CreateUserManagerMock();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var categoryRepositoryMock = new RepositoryMocks().CategoryRepositoryMock;
            var tagRepositoryMock = new RepositoryMocks().TagRepositoryMock;
            var automapper = AutoMapperFactory.Create();

            userManagerMock
                .Setup(x => x.FindByNameAsync("Rambo"))
                .Returns(Task.FromResult(
                    new ApplicationUser()
                    {
                        Id = "Rambo",
                        UserName = "Rambo",
                        Email = "rambo@mail.com",
                    }
                 ));

            var sut = new AdminController(
                userManagerMock.Object,
                postRepositoryMock,
                categoryRepositoryMock,
                tagRepositoryMock,
                automapper
            );

            // ACT
            var post = new EditPostViewModel()
            {
                Header = "Extra Test Header",
                Content = "This is my marvellous test content",
                PublishedDate = new DateTimeOffset(2021, 03, 31, 0, 0, 0, new TimeSpan(2, 0, 0)),
                PublishedTime = new DateTimeOffset(2021, 03, 31, 7, 42, 34, new TimeSpan(2, 0, 0)),
                FormSumbissionDateTimeUtc = new DateTimeOffset(2021, 03, 31, 5, 42, 34, new TimeSpan(0, 0, 0)),
                SelectedCategory = "Maximus",
                SelectedTags = new[] { "interdum", "volutpat" },
                SelectedAuthor = "Rambo"
            };
            var result = sut.AddPost(post);

            // ASSERT
            var redirectResult = result as RedirectToActionResult;
            Assert.NotNull(redirectResult);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal(nameof(AdminController.Posts), redirectResult.ActionName);
        }

        [Fact]
        public void PassTheSameNumberOfPostsToViewAsReadFromRepository()
        {
            // ARRANGE
            var userManagerMock = IdentityMocksFactory.CreateUserManagerMock();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var categoryRepositoryMock = new RepositoryMocks().CategoryRepositoryMock;
            var tagRepositoryMock = new RepositoryMocks().TagRepositoryMock;
            var automapper = AutoMapperFactory.Create();

            var sut = new AdminController(
                userManagerMock.Object,
                postRepositoryMock,
                categoryRepositoryMock,
                tagRepositoryMock,
                automapper
            );

            // ACT
            var post = new EditPostViewModel();
            var result = sut.Posts();

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewName);

            var viewModel = viewResult.Model as PostViewModel[];

            var expectedPostsCount = postRepositoryMock.GetAll().ToArray().Length;
            var actualPostsCount = viewModel.Length;
            Assert.Equal(expectedPostsCount, actualPostsCount);
        }

        [Fact]
        public void ShowPostDetailsView()
        {
            // ARRANGE
            var userManagerMock = IdentityMocksFactory.CreateUserManagerMock();
            var postRepositoryMock = new RepositoryMocks().PostRepositoryMock;
            var categoryRepositoryMock = new RepositoryMocks().CategoryRepositoryMock;
            var tagRepositoryMock = new RepositoryMocks().TagRepositoryMock;
            var automapper = AutoMapperFactory.Create();

            var sut = new AdminController(
                userManagerMock.Object,
                postRepositoryMock,
                categoryRepositoryMock,
                tagRepositoryMock,
                automapper
            );

            // ACT
            var result = sut.PostDetails(4);

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Equal("PostDetails", viewResult.ViewName);
        }
    }
}
