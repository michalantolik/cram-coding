using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using System;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Models.Repositories
{
    public class CommentRepositoryShould : IDisposable
    {
        private readonly RepositoryMocks mocks;
        private readonly CommentRepository sut;

        public CommentRepositoryShould()
        {
            // ARRANGE
            this.mocks = new RepositoryMocks();
            this.sut = new CommentRepository(this.mocks.AppDbContextMock);
        }

        public void Dispose()
        {
            this.mocks.AppDbContextMock.Database.EnsureDeleted();
        }

        [Fact]
        public void ReturnCommentsAsIQueryableCollection()
        {
            // ACT
            var comments = this.sut.GetAll();

            // ASSERT
            Assert.IsAssignableFrom<IQueryable<Comment>>(comments);
        }

        [Fact]
        public void ReturnAllComments()
        {
            // ACT
            var comments = this.sut.GetAll().ToArray();

            // ASSERT
            Assert.NotNull(comments);
            Assert.Equal(6, comments.Length);

            var expectedIds = new int[] { 1, 2, 3, 5, 6 };
            foreach (var id in expectedIds)
            {
                Assert.Contains(comments, t => t.CommentId == id);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindCommentWhenExists(int tagId)
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
        public void NotFindCommentWhenNotExists(int tagId)
        {
            // ACT
            var tag = this.sut.Find(tagId);

            // ASSERT
            Assert.Null(tag);
        }

        [Fact]
        public void AddComment()
        {
            // ARRANGE
            var newComment = new Comment { CommentId = 12, Content = "Comment 12" };

            // ACT
            this.sut.Add(newComment);

            // ASSERT
            var foundComment = this.sut.Find(12);
            Assert.NotNull(foundComment);
        }

        [Fact]
        public void UpdateComment()
        {
            // ARRANGE
            var tag = this.sut.Find(1);
            tag.Content = "Updated Comment Content";

            // ACT
            this.sut.Update(tag);

            // ASSERT
            var updatedComment = this.sut.Find(1);
            Assert.NotNull(updatedComment);
            Assert.Equal("Updated Comment Content", updatedComment.Content);
        }

        [Fact]
        public void DeleteComment()
        {
            // ARRANGE
            var tag = this.sut.Find(2);
            Assert.NotNull(tag);

            // ACT
            this.sut.Delete(tag);

            // ASSERT
            var deletedComment = this.sut.Find(2);
            Assert.Null(deletedComment);
        }
    }
}
