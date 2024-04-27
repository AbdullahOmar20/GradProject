using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class OTPVerificationDto
    {
        [Required(ErrorMessage = "OTP is required")]
        public string EnteredOTP { get; set; }
    }
}
