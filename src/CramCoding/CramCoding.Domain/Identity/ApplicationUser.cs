using Microsoft.AspNetCore.Identity;

namespace CramCoding.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
