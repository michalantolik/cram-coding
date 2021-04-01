using CramCoding.WebApp.ViewModels.Admin.Post;
using System;
using Xunit;

namespace CramCoding.UnitTests.ViewModels
{
    public class EditPostViewModelShould
    {
        [Theory]
        [InlineData(7, 5, 2, 25, 25)]
        [InlineData(7, 3, 4, 25, 25)]
        [InlineData(7, 1, 6, 25, 25)]
        [InlineData(7, 0, 7, 25, 25)]
        [InlineData(7, -2, 9, 25, 25)]
        [InlineData(7, -4, 11, 25, 25)]
        public void ReturnMergedPublishedDateTimeUtcWhenOffsetDifferenceResultsInTheSameDay(
            int localHour, int localHourOffsetToUtc, int expectedUtcHour, int localDay, int expectedUtcDay)
        {
            // ARRANGE
            var sut = new EditPostViewModel()
            {
                PublishedDate = new DateTimeOffset(2021, 10, localDay, 0, 0, 0,
                    new TimeSpan(2, 0, 0)),

                PublishedTime = new DateTimeOffset(2021, 10, 2, localHour, 42, 34,
                    new TimeSpan(localHourOffsetToUtc, 0, 0)),
            };

            // ACT
            var publishedDateTimeUtc = sut.PublishedDateTimeUtc;

            // ASSERT
            Assert.Equal(2021, publishedDateTimeUtc.Value.Year);
            Assert.Equal(10, publishedDateTimeUtc.Value.Month);
            Assert.Equal(expectedUtcDay, publishedDateTimeUtc.Value.Day);

            Assert.Equal(expectedUtcHour, publishedDateTimeUtc.Value.Hour);
            Assert.Equal(42, publishedDateTimeUtc.Value.Minute);
            Assert.Equal(34, publishedDateTimeUtc.Value.Second);

            Assert.Equal(0, publishedDateTimeUtc.Value.Offset.Hours);
        }

        [Theory]
        [InlineData(7, 8, 23, 25, 24)]
        [InlineData(23, -3, 2, 25, 26)]
        [InlineData(0, 4, 20, 25, 24)]
        [InlineData(22, -6, 4, 25, 26)]
        public void ReturnMergedPublishedDateTimeUtcWhenOffsetDifferenceResultsInDifferentDay(
            int localHour, int localHourOffsetToUtc, int expectedUtcHour, int localDay, int expectedUtcDay)
        {
            // ARRANGE
            var sut = new EditPostViewModel()
            {
                PublishedDate = new DateTimeOffset(2021, 10, localDay, 0, 0, 0,
                    new TimeSpan(2, 0, 0)),

                PublishedTime = new DateTimeOffset(2021, 10, 2, localHour, 42, 34,
                    new TimeSpan(localHourOffsetToUtc, 0, 0)),
            };

            // ACT
            var publishedDateTimeUtc = sut.PublishedDateTimeUtc;

            // ASSERT
            Assert.Equal(2021, publishedDateTimeUtc.Value.Year);
            Assert.Equal(10, publishedDateTimeUtc.Value.Month);
            Assert.Equal(expectedUtcDay, publishedDateTimeUtc.Value.Day);

            Assert.Equal(expectedUtcHour, publishedDateTimeUtc.Value.Hour);
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
    }
}
