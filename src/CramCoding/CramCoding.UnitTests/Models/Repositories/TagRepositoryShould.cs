using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using System;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Models.Repositories
{
    public class TagRepositoryShould : IDisposable
    {
        private readonly RepositoryMocks mocks;
        private readonly TagRepository sut;

        public TagRepositoryShould()
        {
            // ARRANGE
            this.mocks = new RepositoryMocks();
            this.sut = new TagRepository(this.mocks.AppDbContextMock);
        }

        public void Dispose()
        {
            this.mocks.AppDbContextMock.Database.EnsureDeleted();
        }

        [Fact]
        public void ReturnTagsAsIQueryableCollection()
        {
            // ACT
            var tags = this.sut.GetAll();

            // ASSERT
            Assert.IsAssignableFrom<IQueryable<Tag>>(tags);
        }

        [Fact]
        public void ReturnAllTags()
        {
            // ACT
            var tags = this.sut.GetAll().ToArray();

            // ASSERT
            Assert.NotNull(tags);
            Assert.Equal(3, tags.Length);

            var expectedIds = new int[] { 1, 2, 3 };
            foreach (var id in expectedIds)
            {
                Assert.Contains(tags, t => t.TagId == id);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindTagWhenExists(int tagId)
        {
            // ACT
            var tag = this.sut.Find(tagId);

            // ASSERT
            Assert.NotNull(tag);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(23)]
        public void NotFindTagWhenNotExists(int tagId)
        {
            // ACT
            var tag = this.sut.Find(tagId);

            // ASSERT
            Assert.Null(tag);
        }

        [Fact]
        public void AddTag()
        {
            // ARRANGE
            var newTag = new Tag { TagId = 12, Name = "Tag 12" };

            // ACT
            this.sut.Add(newTag);

            // ASSERT
            var foundTag = this.sut.Find(12);
            Assert.NotNull(foundTag);
        }

        [Fact]
        public void UpdateTag()
        {
            // ARRANGE
            var tag = this.sut.Find(1);
            tag.Name = "Updated Tag Name";

            // ACT
            this.sut.Update(tag);

            // ASSERT
            var updatedTag = this.sut.Find(1);
            Assert.NotNull(updatedTag);
            Assert.Equal("Updated Tag Name", updatedTag.Name);
        }

        [Fact]
        public void DeleteTag()
        {
            // ARRANGE
            var tag = this.sut.Find(2);
            Assert.NotNull(tag);

            // ACT
            this.sut.Delete(tag);

            // ASSERT
            var deletedTag = this.sut.Find(2);
            Assert.Null(deletedTag);
        }
    }
}
