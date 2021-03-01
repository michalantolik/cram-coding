using CramCoding.Domain.Entities;
using System;
using Xunit;

namespace CramCoding.UnitTests.Models.EntityClasses
{
    public class PostShould
    {
        [Fact]
        public void InitializeCategoriesCollection()
        {
            var sut = new Post();
            Assert.NotNull(sut.Categories);
            Assert.Empty(sut.Categories);
        }

        [Fact]
        public void InitializeTagsCollection()
        {
            var sut = new Post();
            Assert.NotNull(sut.Tags);
            Assert.Empty(sut.Tags);
        }

        [Theory]
        [InlineData("Architektura oprogramowania", "posts/architektura-oprogramowania")]
        [InlineData("Relacyjne bazy danych", "posts/relacyjne-bazy-danych")]
        [InlineData("Entity Framework Core - migracja schematu bazy danych", "posts/entity-framework-core-migracja-schematu-bazy-danych")]
        public void ReadSlugForValidHeader(string header, string slug)
        {
            var sut = new Post { Header = header };
            Assert.Equal(slug, sut.Slug);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("  ")]
        [InlineData("")]
        public void ThrowExceptionWhenSlugIsReadForInvalidHeader(string header)
        {
            var sut = new Post { Header = header };
            Assert.Throws<InvalidOperationException>(() => sut.Slug);
        }
    }
}
