using Microsoft.AspNetCore.Identity;

namespace CramCoding.Domain.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
