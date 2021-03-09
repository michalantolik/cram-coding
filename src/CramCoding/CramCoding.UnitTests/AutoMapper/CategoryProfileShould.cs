using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.AutoMapper;
using CramCoding.WebApp.ViewModels;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.AutoMapper
{
    public class CategoryProfileShould
    {
        [Fact]
        public void MapCategoryEntityToViewModel()
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
            var categoryViewModel = mapper.Map<CategoryViewModel>(categoryEntity);

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

        internal IMapper CreateSut()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
