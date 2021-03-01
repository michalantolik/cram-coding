using CramCoding.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CramCoding.Data.Seed
{
    public class AppDbInitializer
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public AppDbInitializer(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            foreach (var role in RolesSeederData.Data)
            {
                var roleName = role.Key.ToString();
                var roleExists = await this.roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    var applicationRole = new ApplicationRole
                    {
                        Name = roleName,
                        Description = role.Value
                    };
                    await this.roleManager.CreateAsync(applicationRole);
                }
            }
        }
    }
}
