using CramCoding.UnitTests.AutoMapper;
using CramCoding.UnitTests.Identity;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Controllers;
using CramCoding.WebApp.ViewModels.Admin.Category;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Controllers
{
    public partial class AdminControllerShould
    {
        [Fact]
        public void ReturnCurrentFormViewWhenAddingInvalidCategory()
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

            sut.ModelState.AddModelError("CategoryName", "Category name is required");

            // ACT
            var category = new EditCategoryViewModel();
            var result = sut.AddCategory(category);

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void RedirectToCategoriesWhenAddingValidPost()
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
            var category = new EditCategoryViewModel()
            {
                CategoryName = "web-development"
            };
            var result = sut.AddCategory(category);

            // ASSERT
            var redirectResult = result as RedirectToActionResult;
            Assert.NotNull(redirectResult);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal(nameof(AdminController.Categories), redirectResult.ActionName);
        }

        [Fact]
        public void PassTheSameNumberOfCategoriesToViewAsReadFromRepository()
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
            var category = new EditCategoryViewModel();
            var result = sut.Categories();

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewName);

            var viewModel = viewResult.Model as CategoryViewModel[];

            var expectedTCategoriesCount = categoryRepositoryMock.GetAll().ToArray().Length;
            var actualCategoriesCount = viewModel.Length;
            Assert.Equal(expectedTCategoriesCount, actualCategoriesCount);
        }
    }
}
