using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Authentication
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }


    }
}
