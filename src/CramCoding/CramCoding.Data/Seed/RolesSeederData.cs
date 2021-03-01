using CramCoding.Domain.Identity;
using System.Collections.Generic;

namespace CramCoding.Data.Seed
{
    internal static class RolesSeederData
    {
        internal static Dictionary<Role, string> Data => new Dictionary<Role, string>
        {
            [Role.AdminUser] = "Blog administrator role",
            [Role.BasicUser] = "Blog visitor role"
        };
    }
}
