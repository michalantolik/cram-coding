using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Category;
using CramCoding.WebApp.ViewModels.ViewComponents.CategoryMenu;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.AutoMapper
{
    public class CategoryProfileShould
    {
        [Fact]
        public void MapCategoryEntityToMenuCategoryViewModel()
        {
            // ARRANGE
            var categoryEntity = new Category
            {
                CategoryId = 1,
                Name = "Hero Category",
                Children = new Category[]
                 {
                     new Category { CategoryId = 2, Name = "Category ABC" },
                     new Category { CategoryId = 3, Name = "Category DEF" },
                     new Category { CategoryId = 4, Name = "Category XYZ" }
                 }
            };

            // ACT
            var mapper = CreateSut();
            var categoryViewModel = mapper.Map<MenuCategoryViewModel>(categoryEntity);

            // ASSERT
            Assert.Equal("Hero Category", categoryViewModel.CategoryName);
            Assert.NotNull(categoryViewModel.Subcategories);
            Assert.Equal(3, categoryViewModel.Subcategories.Count());

            for (int i = 0; i < categoryEntity.Children.Count; i++)
            {
                var sourceName = categoryEntity.Children.ElementAt(i).Name;
                var destName = categoryViewModel.Subcategories.ElementAt(i);
                Assert.Equal(sourceName, destName);
            }
        }

        [Theory]
        [InlineData("architecture")]
        [InlineData("javascript")]
        [InlineData("web-development")]
        public void MapCategoryEntityToEditCategoryViewModel(string categoryName)
        {
            // ARRANGE
            var categoryEntity = new Category
            {
                Name = categoryName
            };

            // ACT
            var mapper = CreateSut();
            var editCategoryViewModel = mapper.Map<EditCategoryViewModel>(categoryEntity);

            // ASSERT
            Assert.Equal(categoryName, editCategoryViewModel.CategoryName);
        }

        [Theory]
        [InlineData("architecture")]
        [InlineData("javascript")]
        [InlineData("web-development")]
        public void MapEditCategoryViewModelToCategoryEntity(string categoryName)
        {
            // ARRANGE
            var editCategoryViewModel = new EditCategoryViewModel
            {
                CategoryName = categoryName
            };

            // ACT
            var mapper = CreateSut();
            var categoryEntity = mapper.Map<Category>(editCategoryViewModel);

            // ASSERT
            Assert.Equal(categoryName, categoryEntity.Name);
        }

        internal IMapper CreateSut()
        {
            return AutoMapperFactory.Create();
        }
    }
}
