using CramCoding.WebApp.Models.EntityClasses;
using Xunit;

namespace CramCoding.UnitTests.Models.EntityClasses
{
    public class CategoryShould
    {
        [Fact]
        public void InitializePostsCollection()
        {
            var sut = new Category();
            Assert.NotNull(sut.Posts);
            Assert.Empty(sut.Posts);
        }
    }
}
