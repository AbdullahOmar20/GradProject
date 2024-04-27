using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "New Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 8 characters long")]
        public string NewPassword { get; set; }


        public string EmailAddress { get; set; }
        public string OTP { get; set; }
    }
}
