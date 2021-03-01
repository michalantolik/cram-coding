using CramCoding.Domain.Entities;
using Xunit;

namespace CramCoding.UnitTests.Models.EntityClasses
{
    public class TagShould
    {
        [Fact]
        public void InitializePostsCollection()
        {
            var sut = new Tag();
            Assert.NotNull(sut.Posts);
            Assert.Empty(sut.Posts);
        }
    }
}
