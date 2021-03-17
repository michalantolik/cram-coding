using CramCoding.Data;
using CramCoding.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace CramCoding.UnitTests.Models.Repositories.Mocks
{
    /// <summary>
    /// This class contains mocks of the repository dependencies
    /// </summary>
    /// <remarks>It does NOT contain a mock of the repository class itself</remarks>
    internal class RepositoryMocks
    {
        public AppDbContext AppDbContextMock { get; set; }

        public ICategoryRepository CategoryRepositoryMock { get; set; }

        public RepositoryMocks()
        {
            InitializeDbContextMock();
        }

        private void InitializeDbContextMock()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(InMemoryDbName).Options;
            AppDbContextMock = new AppDbContext(options);

            var repositoryData = new RepositoryData();
            AppDbContextMock.AddRange(repositoryData.Categories);
            AppDbContextMock.AddRange(repositoryData.Comments);
            AppDbContextMock.AddRange(repositoryData.Post);
            AppDbContextMock.AddRange(repositoryData.Tags);
            AppDbContextMock.SaveChanges();

            CategoryRepositoryMock = new CategoryRepository(AppDbContextMock);
        }

        /// <summary>
        /// Provides a unique in memory database name.
        /// It makes it possible to run test methods in parallel.
        /// Each test method should use a new instance of the <see cref="RepositoryMocks"/> ...
        /// ... so that unique database name gets generated.
        /// </summary>
        private string InMemoryDbName => Guid.NewGuid().ToString();
    }
}
