using CramCoding.UnitTests.AutoMapper;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Components.CategoryMenu;
using CramCoding.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Components
{
    public class CategoryMenuShould
    {
        [Fact]
        public void InitializeViewWithCorrectViewModel()
        {
            // ARRANGE
            var automapper = AutoMapperFactory.Create();
            var categoryRepositoryMock = new RepositoryMocks().CategoryRepositoryMock;
            var sut = new CategoryMenu(automapper, categoryRepositoryMock);

            // ... based on data in "categoryRepositoryMock"
            var expectedCategories = new[]
            {
                new CategoryViewModel()
                {
                    CategoryName = "Category 1",
                    Subcategories = new[] { "Subcategory 1", "Subcategory 2", "Subcategory 3" }
                },
                new CategoryViewModel()
                {
                    CategoryName = "Category 3",
                    Subcategories = new[] { "Subcategory 6", "Subcategory 7", "Subcategory 8" }
                },
                new CategoryViewModel()
                {
                    CategoryName = "Category 2",
                    Subcategories = new[] { "Subcategory 4", "Subcategory 5", }
                },
            };

            // ACT
            var view = sut.Invoke() as ViewViewComponentResult;

            // ASSERT
            Assert.NotNull(view);

            var viewModel = view.ViewData.Model as CategoryMenuViewModel;
            Assert.NotNull(viewModel);

            var actualMainCategories = viewModel.Categories.ToArray();
            Assert.Equal(expectedCategories.Length, actualMainCategories.Length);
            for (int i = 0; i < actualMainCategories.Length; i++)
            {
                // main categories
                var expectedMainCategory = expectedCategories[i].CategoryName;
                var actualMainCategory = actualMainCategories[i].CategoryName;

                Assert.Equal(expectedMainCategory, actualMainCategory);

                //subcategories
                var expectedSubcategories = expectedCategories[i].Subcategories.ToArray();
                var actualSubcategories = actualMainCategories[i].Subcategories.ToArray();

                Assert.Equal(expectedSubcategories.Length, actualSubcategories.Length);
                for (int j = 0; j < actualSubcategories.Length; j++)
                {
                    Assert.Equal(expectedSubcategories[j], actualSubcategories[j]);
                }
            }
        }
    }
}
