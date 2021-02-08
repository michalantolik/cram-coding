using Microsoft.AspNetCore.Identity;

namespace CramCoding.WebApp.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
