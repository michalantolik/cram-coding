using Microsoft.AspNetCore.Identity;

namespace CramCoding.WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
