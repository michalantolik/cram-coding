using CramCoding.WebApp.ViewModels.Admin.Post;
using System;
using Xunit;

namespace CramCoding.UnitTests.ViewModels
{
    public class EditPostViewModelShould
    {
        [Fact]
        public void ReturnMergedPublishedDateTimeUtcWhenPublishedDateAndPublishedTimeAreNotNull()
        {
            // ARRANGE
            var sut = new EditPostViewModel()
            {
                PublishedDate = new DateTimeOffset(2021, 03, 31, 0, 0, 0, new TimeSpan(2, 0, 0)),
                PublishedTime = new DateTimeOffset(1532, 10, 31, 7, 42, 34, new TimeSpan(2, 0, 0)),
            };

            // ACT
            var publishedDateTimeUtc = sut.PublishedDateTimeUtc;

            // ASSERT
            Assert.Equal(2021, publishedDateTimeUtc.Value.Year);
            Assert.Equal(03, publishedDateTimeUtc.Value.Month);
            Assert.Equal(31, publishedDateTimeUtc.Value.Day);

            Assert.Equal(5, publishedDateTimeUtc.Value.Hour);
            Assert.Equal(42, publishedDateTimeUtc.Value.Minute);
            Assert.Equal(34, publishedDateTimeUtc.Value.Second);

            Assert.Equal(0, publishedDateTimeUtc.Value.Offset.Hours);
        }

        [Fact]
        public void ReturnNullPublishedDateTimeUtcWhenNullPublishedDate()
        {
            // ARRANGE
            var sut = new EditPostViewModel()
            {
                PublishedDate = null,
                PublishedTime = new DateTimeOffset(2021, 03, 31, 7, 42, 34, new TimeSpan(2, 0, 0))
            };

            // ACT
            var publishedDateTimeUtc = sut.PublishedDateTimeUtc;

            // ASSERT
            Assert.Null(publishedDateTimeUtc);
        }

        [Fact]
        public void ReturnNullPublishedDateTimeUtcWhenPublishedTimeIsNull()
        {
            // ARRANGE
            var sut = new EditPostViewModel()
            {
                PublishedDate = new DateTimeOffset(2021, 03, 31, 7, 42, 34, new TimeSpan(2, 0, 0)),
                PublishedTime = null
            };

            // ACT
            var publishedDateTimeUtc = sut.PublishedDateTimeUtc;

            // ASSERT
            Assert.Null(publishedDateTimeUtc);
        }

        [Fact]
        public void ReturnNullPublishedDateTimeUtcWhenPublishedDateIsNullAndPublishedTimeIsNull()
        {
            // ARRANGE
            var sut = new EditPostViewModel()
            {
                PublishedDate = null,
                PublishedTime = null
            };

            // ACT
            var publishedDateTimeUtc = sut.PublishedDateTimeUtc;

            // ASSERT
            Assert.Null(publishedDateTimeUtc);
        }

        [Fact]
        public void ReturnNullPublishedDateTimeUtcWhenDateAndTimeOffsetsMismatch()
        {
            // ARRANGE
            var sut = new EditPostViewModel()
            {
                PublishedDate = new DateTimeOffset(2021, 03, 31, 0, 0, 0, new TimeSpan(2, 0, 0)),
                PublishedTime = new DateTimeOffset(2021, 10, 31, 7, 42, 34, new TimeSpan(4, 0, 0)),
            };

            // ACT
            var publishedDateTimeUtc = sut.PublishedDateTimeUtc;

            // ASSERT
            Assert.Null(publishedDateTimeUtc);
        }
    }
}
