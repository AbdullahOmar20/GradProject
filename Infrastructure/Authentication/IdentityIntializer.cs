using System.Security.Claims;
using Core.Entites.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Authentication
{
    public class IdentityIntializer
    {
        public static async Task IntializeRole(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, string email)
        {
            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                var role = new IdentityRole("Manager");
                await roleManager.CreateAsync(role);
                await roleManager.AddClaimAsync(role,new Claim("can_edit",""));
            }
            User user = await userManager.FindByNameAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Email=email,
                    FirstName="",
                    LastName=""
                };
                await userManager.CreateAsync(user,"");

            }
            await userManager.AddToRoleAsync(user, "Manager");
        }
    }
}