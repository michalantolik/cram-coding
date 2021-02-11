using CramCoding.WebApp.Models.EntityClasses;
using System;
using Xunit;

namespace CramCoding.UnitTests.Models.EntityClasses
{
    public class PostShould
    {
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
