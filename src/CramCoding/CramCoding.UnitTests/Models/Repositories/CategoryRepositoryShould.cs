﻿using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using System;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Models.Repositories
{
    public class CategoryRepositoryShould : IDisposable
    {
        private readonly RepositoryMocks mocks;
        private readonly CategoryRepository sut;

        public CategoryRepositoryShould()
        {
            // ARRANGE
            this.mocks = new RepositoryMocks();
            this.sut = new CategoryRepository(this.mocks.AppDbContextMock);
        }

        public void Dispose()
        {
            this.mocks.AppDbContextMock.Database.EnsureDeleted();
        }

        [Fact]
        public void ReturnCategoriesAsIQueryableCollection()
        {
            // ACT
            var categories = this.sut.GetAll();

            // ASSERT
            Assert.IsAssignableFrom<IQueryable<Category>>(categories);
        }

        [Fact]
        public void ReturnAllCategories()
        {
            // ACT
            var categories = this.sut.GetAll().ToArray();

            // ASSERT
            Assert.NotNull(categories);
            Assert.Equal(11, categories.Length);

            var expectedIds = Enumerable.Range(1, 11);
            foreach (var id in expectedIds)
            {
                Assert.Contains(categories, t => t.CategoryId == id);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindCategoryWhenExists(int categoryId)
        {
            // ACT
            var category = this.sut.FindById(categoryId);

            // ASSERT
            Assert.NotNull(category);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(53)]
        [InlineData(243)]
        public void NotFindCategoryWhenNotExists(int categoryId)
        {
            // ACT
            var category = this.sut.FindById(categoryId);

            // ASSERT
            Assert.Null(category);
        }

        [Fact]
        public void AddCategory()
        {
            // ARRANGE
            var newCategory = new Category { CategoryId = 132, Name = "Category 12" };

            // ACT
            this.sut.Add(newCategory);

            // ASSERT
            var foundCategory = this.sut.FindById(132);
            Assert.NotNull(foundCategory);
        }

        [Fact]
        public void UpdateCategory()
        {
            // ARRANGE
            var category = this.sut.FindById(1);
            category.Name = "Updated Category Name";

            // ACT
            this.sut.Update(category);

            // ASSERT
            var updatedCategory = this.sut.FindById(1);
            Assert.NotNull(updatedCategory);
            Assert.Equal("Updated Category Name", updatedCategory.Name);
        }

        [Fact]
        public void DeleteCategory()
        {
            // ARRANGE
            var category = this.sut.FindById(2);
            Assert.NotNull(category);

            // ACT
            this.sut.Delete(category);

            // ASSERT
            var deletedCategory = this.sut.FindById(2);
            Assert.Null(deletedCategory);
        }
    }
}
