using CramCoding.UnitTests.Identity;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Controllers;
using CramCoding.WebApp.ViewModels.Admin.Post;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CramCoding.UnitTests.Controllers
{
    public class AdminControllerShould
    {
        [Fact]
        public void ReturnCurrentFormViewWhenAddingInvalidPost()
        {
            // ARRANGE
            var userManagerMock = IdentityMocksFactory.CreateUserManagerMock();
            var categoryRepositoryMock = new RepositoryMocks().CategoryRepositoryMock;
            var tagRepositoryMock = new RepositoryMocks().TagRepositoryMock;

            var sut = new AdminController(userManagerMock.Object, categoryRepositoryMock, tagRepositoryMock);
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
            var categoryRepositoryMock = new RepositoryMocks().CategoryRepositoryMock;
            var tagRepositoryMock = new RepositoryMocks().TagRepositoryMock;

            var sut = new AdminController(userManagerMock.Object, categoryRepositoryMock, tagRepositoryMock);

            // ACT
            var post = new EditPostViewModel();
            var result = sut.AddPost(post);

            // ASSERT
            var redirectResult = result as RedirectToActionResult;
            Assert.NotNull(redirectResult);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal(nameof(AdminController.Posts), redirectResult.ActionName);
        }
    }
}
