using Core.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class AppIdentityContentSeed
    {
        public static async Task SeedusersAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    FirstName = "Abdullah",
                    LastName ="omar",
                    Email = "abdullah@test.com",
                    UserName = "abdullah@test.com",
                    
                    
                };
                await userManager.CreateAsync(user, "@@sW0rd1234");
            }
        }
    }
}
