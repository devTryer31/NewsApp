using Microsoft.AspNetCore.Identity;

namespace News.Identity.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}