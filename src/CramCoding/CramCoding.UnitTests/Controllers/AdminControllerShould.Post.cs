using CramCoding.Domain.Entities;
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

            var viewModel = viewResult.Model as AdminPostViewModel[];

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
            Assert.Null(viewResult.ViewName);

            var post = viewResult.Model as Post;
            Assert.NotNull(post);

            // ... based on data in "postRepositoryMock"

            Assert.Equal("john.rambo@gmail.com", post.Author.Email);
            Assert.Equal("Header 4", post.Header);
            Assert.Equal("Content 4", post.Content);


            Assert.NotNull(post.Categories);
            Assert.Equal(1, post.Categories.Count);
            Assert.Equal("Subcategory 8", post.Categories.ElementAt(0).Name);

            Assert.NotNull(post.Tags);
            Assert.Equal(1, post.Tags.Count);
            Assert.Equal("Tag 2", post.Tags.ElementAt(0).Name);
        }

        [Fact]
        public void OpenNewPostForm()
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
            var viewResult = sut.AddPost() as ViewResult;

            // ASSERT
            Assert.NotNull(viewResult);

            var viewModel = viewResult.Model as EditPostViewModel;
            Assert.NotNull(viewModel);

            Assert.Null(viewModel.Header);
            Assert.Null(viewModel.Content);
            Assert.Null(viewModel.SelectedAuthor);
            Assert.Null(viewModel.SelectedCategory);
            Assert.Null(viewModel.SelectedTags);
            Assert.Null(viewModel.PublishedDate);
            Assert.Null(viewModel.PublishedTime);
            Assert.False(viewModel.IsVisible);
        }

        [Fact]
        public void OpenEditPostForm()
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
            var viewResult = sut.EditPost(2) as ViewResult;

            // ASSERT
            Assert.NotNull(viewResult);

            var viewModel = viewResult.Model as EditPostViewModel;
            Assert.NotNull(viewModel);

            // ... based on data in "postRepositoryMock"

            Assert.Equal("Header 2", viewModel.Header);
            Assert.Equal("Content 2", viewModel.Content);
            Assert.Equal("Subcategory 3", viewModel.SelectedCategory);

            Assert.Equal(2, viewModel.SelectedTags.Length);
            Assert.Equal("Tag 2", viewModel.SelectedTags[0]);
            Assert.Equal("Tag 3", viewModel.SelectedTags[1]);

            Assert.Equal(new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                viewModel.PublishedDate);

            Assert.Equal(new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                viewModel.PublishedTime);

            Assert.True(viewModel.IsVisible);
        }

        [Fact]
        public void DeletePost()
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

            // Post exists in DB before delete
            Assert.NotNull(postRepositoryMock.FindById(3));

            // ACT
            sut.DeletePost(3);

            // ASSERT - Post does NOT exist in DB after delete
            Assert.Null(postRepositoryMock.FindById(3));
        }
    }
}
