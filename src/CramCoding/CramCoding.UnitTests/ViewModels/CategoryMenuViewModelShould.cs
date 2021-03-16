using CramCoding.Data.Repositories;
using CramCoding.Domain.Entities;
using CramCoding.UnitTests.AutoMapper;
using Moq;
using System.Linq;
using Xunit;

namespace CramCoding.UnitTests.ViewModels
{
    public class CategoryMenuViewModelShould
    {
        [Fact]
        public void SortSubcategoriesAlphabetically()
        {
            // ARRANGE
            var mapper = AutoMapperFactory.Create();

            var topCategory1 = new Category { Name = "Some main category" };
            var topCategory2 = new Category { Name = "Another main category" };

            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            categoryRepositoryMock.Setup(x => x.GetAll(true)).Returns(new Category[]
            {
                new Category
                {
                     Name = "Some main category",
                     Parent = null,
                     Children = new Category[]
                     {
                         new Category { Parent = new Category(), }
                     }
                }
            }
            .AsQueryable());
        }
    }
}
