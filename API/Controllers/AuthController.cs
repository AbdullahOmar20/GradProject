
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





	}
}

   