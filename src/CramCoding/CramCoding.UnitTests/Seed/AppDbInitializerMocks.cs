using CramCoding.Data.Repositories;
using CramCoding.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CramCoding.UnitTests.Seed
{
    internal class AppDbInitializerMocks
    {
        internal Mock<RoleManager<ApplicationRole>> RoleManagerMock { get; set; }
        internal Mock<IPostRepository> PostRepositoryMock { get; set; }


        internal AppDbInitializerMocks()
        {
            InitializeRoleManagerMock();
            InitializePostRepositoryMock();
        }

        private void InitializeRoleManagerMock()
        {
            var roleStoreMock = new Mock<IRoleStore<ApplicationRole>>();
            RoleManagerMock = new Mock<RoleManager<ApplicationRole>>(
                roleStoreMock.Object, null, null, null, null
            );
        }

        private void InitializePostRepositoryMock()
        {
            PostRepositoryMock = new Mock<IPostRepository>();
        }
    }
}
