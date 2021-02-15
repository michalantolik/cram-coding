using CramCoding.WebApp.Models;
using CramCoding.WebApp.Models.EntityClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CramCoding.UnitTests.Models.Repositories.Mocks
{
    /// <summary>
    /// This class contains in memory data for an instance of <see cref="DbContext"/>
    /// </summary>
    /// <remarks>It does NOT contain a mock of the repository class itself</remarks>
    internal class RepositoryData
    {
        #region Constructor

        public RepositoryData()
        {
            UpdatePostAuthor();
            UpdatePostCategory();
            UpdatePostTag();
            UpdatePostComment();
        }

        #endregion Constructor


        #region Public properties

        public Post[] Post => this.post;

        public Comment[] Comment => this.comment;

        #endregion Public properties


        #region Methods to update relationships between entities

        private void UpdatePostAuthor()
        {
            LinkPostToUser(1, "3");
            LinkPostToUser(2, "3");
            LinkPostToUser(3, "2");
            LinkPostToUser(4, "1");
            LinkPostToUser(5, "2");

            void LinkPostToUser(int postId, string userId)
            {
                this.post.Single(p => p.PostId == postId).Author = this.user.Single(u => u.Id == userId);
            }
        }

        private void UpdatePostCategory()
        {
            LinkPostToCategory(1, 1);
            LinkPostToCategory(1, 3);
            LinkPostToCategory(2, 2);
            LinkPostToCategory(3, 2);
            LinkPostToCategory(3, 3);
            LinkPostToCategory(4, 1);
            LinkPostToCategory(5, 3);

            void LinkPostToCategory(int postId, int categoryId)
            {
                this.post.Single(p => p.PostId == postId).Categories.Add(
                    this.category.Single(c => c.CategoryId == categoryId)
                );

                this.category.Single(c => c.CategoryId == categoryId).Posts.Add(
                    this.post.Single(p => p.PostId == postId)
                );
            }
        }

        private void UpdatePostTag()
        {
            LinkPostToTag(1, 1);
            LinkPostToTag(2, 2);
            LinkPostToTag(2, 3);
            LinkPostToTag(3, 1);
            LinkPostToTag(3, 3);
            LinkPostToTag(4, 2);
            LinkPostToTag(5, 3);

            void LinkPostToTag(int postId, int tagId)
            {
                this.post.Single(p => p.PostId == postId).Tags.Add(
                    this.tag.Single(c => c.TagId == tagId)
                );

                this.tag.Single(c => c.TagId == tagId).Posts.Add(
                    this.post.Single(p => p.PostId == postId)
                );
            }
        }

        private void UpdatePostComment()
        {
            LinkPostToComment(1, 1);
            LinkPostToComment(1, 2);
            LinkPostToComment(3, 6);
            LinkPostToComment(5, 3);
            LinkPostToComment(5, 4);
            LinkPostToComment(5, 5);

            void LinkPostToComment(int postId, int commentId)
            {
                var post = this.post.Single(p => p.PostId == postId);
                var comment = this.comment.Single(c => c.CommentId == commentId);

                this.post.Single(p => p.PostId == postId).Comments.Add(
                    this.comment.Single(c => c.CommentId == commentId)
                );

                this.comment.Single(c => c.CommentId == commentId)
                    .Post = this.post.Single(p => p.PostId == postId
                );
            }
        }

        #endregion Methods to update relationships between entities


        #region Post data

        private Post[] post = new Post[]
        {
            new Post
            {
                 PostId = 1,
                 Header = "Header 1",
                 Content = "Content 1",
                 CreatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                 UpdatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                 PublishedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                 IsVisible = true,
                 ViewsCount = 23,
            },
            new Post
            {
                 PostId = 2,
                 Header = "Header 2",
                 Content = "Content 2",
                 CreatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                 UpdatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                 PublishedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                 IsVisible = true,
                 ViewsCount = 0,
            },
            new Post
            {
                 PostId = 3,
                 Header = "Header 3",
                 Content = "Content 3",
                 CreatedAt = new DateTimeOffset(2021, 01, 01, 09, 43, 53, 235, new TimeSpan(2, 0, 0)),
                 UpdatedAt = new DateTimeOffset(2021, 01, 01, 09, 43, 53, 235, new TimeSpan(2, 0, 0)),
                 PublishedAt = new DateTimeOffset(2021, 01, 01, 09, 43, 53, 235, new TimeSpan(2, 0, 0)),
                 IsVisible = true,
                 ViewsCount = 8,
            },
            new Post
            {
                 PostId = 4,
                 Header = "Header 4",
                 Content = "Content 4",
                 CreatedAt = new DateTimeOffset(2021, 02, 11, 22, 12, 05, 643, new TimeSpan(2, 0, 0)),
                 UpdatedAt = new DateTimeOffset(2021, 02, 11, 22, 12, 05, 643, new TimeSpan(2, 0, 0)),
                 PublishedAt = new DateTimeOffset(2021, 02, 11, 22, 12, 05, 643, new TimeSpan(2, 0, 0)),
                 IsVisible = true,
                 ViewsCount = 53,
            },
            new Post
            {
                 PostId = 5,
                 Header = "Header 5",
                 Content = "Content 5",
                 CreatedAt = new DateTimeOffset(2021, 02, 14, 20, 25, 35, 024, new TimeSpan(2, 0, 0)),
                 UpdatedAt = new DateTimeOffset(2021, 02, 14, 20, 25, 35, 024, new TimeSpan(2, 0, 0)),
                 PublishedAt = new DateTimeOffset(2021, 02, 14, 20, 25, 35, 024, new TimeSpan(2, 0, 0)),
                 IsVisible = false,
                 ViewsCount = 523,
            },
        };

        #endregion Post data


        #region Category data

        private Category[] category = new Category[]
        {
            new Category
            {
                CategoryId = 1,
                Name = "Category 1",
            },
            new Category
            {
                CategoryId = 2,
                Name = "Category 2",
            },
            new Category
            {
                CategoryId = 3,
                Name = "Category 3",
            },
        };

        #endregion Category data


        #region Tag data

        private Tag[] tag = new Tag[]
        {
            new Tag
            {
                TagId = 1,
                Name = "Tag 1",
            },
            new Tag
            {
                TagId = 2,
                Name = "Tag 2",
            },
            new Tag
            {
                TagId = 3,
                Name = "Tag 3",
            },
        };

        #endregion Tag data


        #region Comment data

        private Comment[] comment = new Comment[]
        {
            new Comment
            {
                CommentId = 1,
                Content = "Comment 1",
            },
            new Comment
            {
                CommentId = 2,
                Content = "Comment 2",
            },
            new Comment
            {
                CommentId = 3,
                Content = "Comment 3",
            },
            new Comment
            {
                CommentId = 4,
                Content = "Comment 4",
            },
            new Comment
            {
                CommentId = 5,
                Content = "Comment 5",
            },
            new Comment
            {
                CommentId = 6,
                Content = "Comment 6",
            },
        };

        #endregion Comment data


        #region User data

        private ApplicationUser[] user = new ApplicationUser[]
        {
            new ApplicationUser
            {
                Id = "1",
                Email = "john.rambo@gmail.com"
            },
            new ApplicationUser
            {
                Id = "2",
                Email = "captain.america@gmail.com"
            },
            new ApplicationUser
            {
                Id = "3",
                Email = "johny.bravo@gmail.com"
            },
        };

        #endregion User data
    }
}
