using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.UnitTests.Models.Repositories.Mocks;
using System;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.Models.Repositories
{
    public class PostRepositoryShould : IDisposable
    {
        private readonly RepositoryMocks mocks;
        private readonly PostRepository sut;

        public PostRepositoryShould()
        {
            // ARRANGE
            this.mocks = new RepositoryMocks();
            this.sut = new PostRepository(this.mocks.AppDbContextMock);
        }

        public void Dispose()
        {
            this.mocks.AppDbContextMock.Database.EnsureDeleted();
        }

        [Fact]
        public void ReturnPostsAsIQueryableCollection()
        {
            // ACT
            var posts = this.sut.GetAll();

            // ASSERT
            Assert.IsAssignableFrom<IQueryable<Post>>(posts);
        }

        [Fact]
        public void ReturnAllPosts()
        {
            // ACT
            var posts = this.sut.GetAll().ToArray();

            // ASSERT
            Assert.NotNull(posts);
            Assert.Equal(5, posts.Length);

            var expectedIds = new int[] { 1, 2, 3, 4, 5 };
            foreach (var id in expectedIds)
            {
                Assert.Contains(posts, t => t.PostId == id);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPostWhenExists(int postId)
        {
            // ACT
            var post = this.sut.Find(postId);

            // ASSERT
            Assert.NotNull(post);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(23)]
        public void NotFindPostWhenNotExists(int postId)
        {
            // ACT
            var post = this.sut.Find(postId);

            // ASSERT
            Assert.Null(post);
        }

        [Fact]
        public void AddPost()
        {
            // ARRANGE
            var newPost = new Post { PostId = 12, Content = "Post 12" };

            // ACT
            this.sut.Add(newPost);

            // ASSERT
            var foundPost = this.sut.Find(12);
            Assert.NotNull(foundPost);
        }

        [Fact]
        public void UpdatePost()
        {
            // ARRANGE
            var post = this.sut.Find(1);
            post.Content = "Updated Post Content";

            // ACT
            this.sut.Update(post);

            // ASSERT
            var updatedPost = this.sut.Find(1);
            Assert.NotNull(updatedPost);
            Assert.Equal("Updated Post Content", updatedPost.Content);
        }

        [Fact]
        public void DeletePost()
        {
            // ARRANGE
            var post = this.sut.Find(2);
            Assert.NotNull(post);

            // ACT
            this.sut.Delete(post);

            // ASSERT
            var deletedPost = this.sut.Find(2);
            Assert.Null(deletedPost);
        }
    }
}
