using Microsoft.AspNetCore.Identity;

namespace Core.Entites.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
