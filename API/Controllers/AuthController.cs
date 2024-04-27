
using Setup_Master.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Core.Entites.Identity;
using Infrastructure.Authentication;

namespace API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
		private readonly UserManager<User> _userManager;

		[ActivatorUtilitiesConstructor]
		public AuthController(IAuthService authService , UserManager<User> userManager)
        {
            _authService = authService;
			_userManager = userManager;	 
        }





        [HttpPost("register")]
          public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { Token = result.Token , ExpireDate = result.Expireson});  //anonymus object
        }



		[HttpPost("login")]  //to get the token 
		public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _authService.GetTokenAsync(model);

			if (!result.IsAuthenticated)
				return BadRequest(result.Message);

			return Ok(result);
		}

        [HttpPost("ForgetPassword")]
        
        public async Task<IActionResult> ForgetPasswordEmail([FromBody] ForgetPasswordDto forgetPasswordDto)
        {
            var result = await _authService.ForgetPasswordEmail(forgetPasswordDto);
            if (result)
            {
                return Ok("OTP sent successfully");
            }
            return BadRequest("Email is incorrect");
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] OTPVerificationDto verificationDto)
        {
            var result = await _authService.VerifyOTP(verificationDto);
            if (result)
            {
                return Ok("OTP verification successful");
            }
            return BadRequest("Invalid or expired OTP");
        }

        [HttpPost("ResetPassword")]
        
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var result = await _authService.ResetPassword(resetPasswordDto);
            if (result)
            {
                return Ok("Password reset successfully.");
            }
            return BadRequest("Invalid or expired OTP");
        }



	}
}

   