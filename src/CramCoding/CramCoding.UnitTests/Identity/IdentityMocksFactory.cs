using CramCoding.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CramCoding.UnitTests.Identity
{
    internal static class IdentityMocksFactory
    {
        internal static Mock<RoleManager<ApplicationRole>> CreateRoleManagerMock()
        {
            var roleStoreMock = new Mock<IRoleStore<ApplicationRole>>();
            var roleManagerMock = new Mock<RoleManager<ApplicationRole>>(
                roleStoreMock.Object, null, null, null, null
            );

            return roleManagerMock;
        }

        internal static Mock<UserManager<ApplicationUser>> CreateUserManagerMock()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null
            );

            return userManagerMock;
        }
    }
}
