using CramCoding.Domain.Entities;
using CramCoding.Domain.Identity;
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
            UpdateCategoryParent();
            UpdatePostAuthor();
            UpdatePostCategory();
            UpdatePostTag();
            UpdatePostComment();
        }

        #endregion Constructor


        #region Public properties

        public Post[] Post => this.posts;

        public Category[] Categories => this.categories;

        public Comment[] Comments => this.comments;

        public Tag[] Tags => this.tags;

        #endregion Public properties


        #region Methods to update relationships between entities

        private void UpdateCategoryParent()
        {
            LinkParentToChild(1, 4);
            LinkParentToChild(1, 5);
            LinkParentToChild(1, 6);
            LinkParentToChild(2, 7);
            LinkParentToChild(2, 8);
            LinkParentToChild(3, 9);
            LinkParentToChild(3, 10);
            LinkParentToChild(3, 11);

            void LinkParentToChild(int parentId, int childId)
            {
                var parentCategory = this.categories.Single(c => c.CategoryId == parentId);
                var childCategory = this.categories.Single(c => c.CategoryId == childId);

                parentCategory.Children.Add(childCategory);
                childCategory.Parent = parentCategory;
            }
        }

        private void UpdatePostAuthor()
        {
            LinkPostToUser(1, "3");
            LinkPostToUser(2, "3");
            LinkPostToUser(3, "2");
            LinkPostToUser(4, "1");
            LinkPostToUser(5, "2");

            void LinkPostToUser(int postId, string userId)
            {
                this.posts.Single(p => p.PostId == postId).Author = this.user.Single(u => u.Id == userId);
            }
        }

        private void UpdatePostCategory()
        {
            LinkPostToCategory(1, 5);
            LinkPostToCategory(1, 5);
            LinkPostToCategory(2, 6);
            LinkPostToCategory(3, 10);
            LinkPostToCategory(3, 9);
            LinkPostToCategory(4, 11);
            LinkPostToCategory(5, 9);

            void LinkPostToCategory(int postId, int categoryId)
            {
                this.posts.Single(p => p.PostId == postId).Categories.Add(
                    this.categories.Single(c => c.CategoryId == categoryId)
                );

                this.categories.Single(c => c.CategoryId == categoryId).Posts.Add(
                    this.posts.Single(p => p.PostId == postId)
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
                this.posts.Single(p => p.PostId == postId).Tags.Add(
                    this.tags.Single(c => c.TagId == tagId)
                );

                this.tags.Single(c => c.TagId == tagId).Posts.Add(
                    this.posts.Single(p => p.PostId == postId)
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
                var post = this.posts.Single(p => p.PostId == postId);
                var comment = this.comments.Single(c => c.CommentId == commentId);

                this.posts.Single(p => p.PostId == postId).Comments.Add(
                    this.comments.Single(c => c.CommentId == commentId)
                );

                this.comments.Single(c => c.CommentId == commentId)
                    .Post = this.posts.Single(p => p.PostId == postId
                );
            }
        }

        #endregion Methods to update relationships between entities


        #region Post data

        private Post[] posts = new Post[]
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

        private Category[] categories = new Category[]
        {
            new Category { CategoryId = 1, Name = "Category 1" },
            new Category { CategoryId = 2,  Name = "Category 2" },
            new Category { CategoryId = 3, Name = "Category 3" },
            new Category { CategoryId = 4,  Name = "Subcategory 1" },
            new Category { CategoryId = 5, Name = "Subcategory 2" },
            new Category { CategoryId = 6, Name = "Subcategory 3" },
            new Category { CategoryId = 7,  Name = "Subcategory 4" },
            new Category { CategoryId = 8, Name = "Subcategory 5" },
            new Category { CategoryId = 9, Name = "Subcategory 6" },
            new Category { CategoryId = 10,  Name = "Subcategory 7" },
            new Category { CategoryId = 11, Name = "Subcategory 8" }
        };

        #endregion Category data


        #region Tag data

        private Tag[] tags = new Tag[]
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

        private Comment[] comments = new Comment[]
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
