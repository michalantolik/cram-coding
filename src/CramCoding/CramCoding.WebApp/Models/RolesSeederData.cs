using System.Collections.Generic;

namespace CramCoding.WebApp.Models
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
