using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CramCoding.WebApp.Models
{
    internal static class AppDbInitializer
    {
        internal static async Task SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            foreach (var role in RolesSeederData.Data)
            {
                var roleName = role.Key.ToString();
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    var applicationRole = new ApplicationRole
                    {
                        Name = roleName,
                        Description = role.Value
                    };
                    await roleManager.CreateAsync(applicationRole);
                }
            }
        }
    }
}
