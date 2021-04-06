using CramCoding.UnitTests.AutoMapper;
using CramCoding.UnitTests.Identity;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Controllers;
using CramCoding.WebApp.ViewModels.Admin.Tag;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Controllers
{
    public partial class AdminControllerShould
    {
        [Fact]
        public void ReturnCurrentFormViewWhenAddingInvalidTag()
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

            sut.ModelState.AddModelError("TagName", "Tag name is required");

            // ACT
            var tag = new EditTagViewModel();
            var result = sut.AddTag(tag);

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void RedirectToTagsWhenAddingValidPost()
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
            var tag = new EditTagViewModel()
            {
                TagName = "web-development"
            };
            var result = sut.AddTag(tag);

            // ASSERT
            var redirectResult = result as RedirectToActionResult;
            Assert.NotNull(redirectResult);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal(nameof(AdminController.Tags), redirectResult.ActionName);
        }

        [Fact]
        public void PassTheSameNumberOfTagsToViewAsReadFromRepository()
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
            var tag = new EditTagViewModel();
            var result = sut.Tags();

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewName);

            var viewModel = viewResult.Model as TagViewModel[];

            var expectedTagsCount = tagRepositoryMock.GetAll().ToArray().Length;
            var actualTagsCount = viewModel.Length;
            Assert.Equal(expectedTagsCount, actualTagsCount);
        }
    }
}
