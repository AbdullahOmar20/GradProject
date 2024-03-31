using AutoMapper;
using Infrastructure.Configuration;

using Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.Services;
using Core.Entites.Identity;

namespace Setup_Master.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper; // Inject IMapper
        private readonly Jwt _jwt;
		private readonly RoleManager<IdentityRole> _roleManager;


		public AuthService(UserManager<User> userManager, IOptions<Jwt> jwt, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _mapper = mapper; // Initialize IMapper
            _roleManager = roleManager;


		}    

        /*
         *  registerModel ==> the form user will fill 
         *  AuthModel ===> the response data after submission
         *  ApplicationUser ==> will assign to database
         * 
         * 
         * */


        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel { Message = "Email is already registered." };
            }

            if (await _userManager.FindByNameAsync(model.Username) is not null)
            {
                return new AuthModel { Message = "Username is already registered." };
            }

            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                // Generate JWT token
                var jwtSecurityToken = await CreateJwtToken(user);

                return new AuthModel
                {
                    Email = user.Email,
                    Expireson = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = new List<string> { "User" },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Username = user.UserName
                };
            }
            else
            {
                // User creation failed, return AuthModel with failure information
                var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                return new AuthModel { Message = errors };
            }
        }



		public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)  //Login Method
		{
			var authModel = new AuthModel();

			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
			{
				authModel.Message = "Email or Password is incorrect!";
				return authModel;
			}

			var jwtSecurityToken = await CreateJwtToken(user);
			var rolesList = await _userManager.GetRolesAsync(user);

			authModel.IsAuthenticated = true;
			authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
			authModel.Email = user.Email;
			authModel.Username = user.UserName;
			authModel.Expireson = jwtSecurityToken.ValidTo;
			authModel.Roles = rolesList.ToList();

			return authModel;
		}



		public async Task<string> AddRoleAsync(AddRoleModel model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId);

			if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
				return "Invalid user ID or Role";

			if (await _userManager.IsInRoleAsync(user, model.Role))
				return "User already assigned to this role";

			var result = await _userManager.AddToRoleAsync(user, model.Role);

			return result.Succeeded ? string.Empty : "Sonething went wrong";
		}



		private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim("uid", user.Id)
    }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
           }

        } 
    }
