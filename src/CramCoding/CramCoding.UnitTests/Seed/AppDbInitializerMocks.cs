using CramCoding.Data.Repositories;
using CramCoding.Domain.Identity;
using CramCoding.UnitTests.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CramCoding.UnitTests.Seed
{
    internal class AppDbInitializerMocks
    {
        internal Mock<RoleManager<ApplicationRole>> RoleManagerMock { get; set; }
        internal Mock<IPostRepository> PostRepositoryMock { get; set; }
        internal Mock<ICategoryRepository> CategoryRepositoryMock { get; set; }
        internal Mock<ITagRepository> TagRepositoryMock { get; set; }


        internal AppDbInitializerMocks()
        {
            InitializeRoleManagerMock();
            InitializePostRepositoryMock();
            InitializeCategoryRepositoryMock();
            InitializeTagRepositoryMock();
        }

        private void InitializeRoleManagerMock()
        {
            RoleManagerMock = IdentityMocksFactory.CreateRoleManagerMock();
        }

        private void InitializePostRepositoryMock()
        {
            PostRepositoryMock = new Mock<IPostRepository>();
        }

        private void InitializeCategoryRepositoryMock()
        {
            CategoryRepositoryMock = new Mock<ICategoryRepository>();
        }

        private void InitializeTagRepositoryMock()
        {
            TagRepositoryMock = new Mock<ITagRepository>();
        }
    }
}
