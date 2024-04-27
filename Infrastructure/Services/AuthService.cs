using AutoMapper;
using Infrastructure.Configuration;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Infrastructure.Services;
using Core.Entites.Identity;
using Microsoft.EntityFrameworkCore;


namespace Setup_Master.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper; // Inject IMapper
        private readonly Jwt _jwt;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EmailService emailService;


        public AuthService(UserManager<User> userManager, IOptions<Jwt> jwt, RoleManager<IdentityRole> roleManager, IMapper mapper,EmailService emailService)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _mapper = mapper; // Initialize IMapper
            _roleManager = roleManager;
            this.emailService=emailService;

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

        public async Task<bool> ForgetPasswordEmail(ForgetPasswordDto forgetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordDto.EmailAddress);

            if (user != null)
            {
                const int otpLength = 6;
                const string allowedChars = "0123456789";

                Random random = new Random();
                char[] otp = new char[otpLength];

                for (int i = 0; i < otpLength; i++)
                {
                    otp[i] = allowedChars[random.Next(0, allowedChars.Length)];
                }
                string otpCode = new string(otp);

                var deleteUserOtp = _userManager.Users.FirstOrDefault(x => x.Id == user.Id);

                if (deleteUserOtp != null)
                {
                    // Clear the OTP and expiry date
                    deleteUserOtp.Otp = null;
                    deleteUserOtp.Expire = null;

                    // Save changes to the database
                    await _userManager.UpdateAsync(deleteUserOtp);
                }

                await SaveOTPInDatabase(new Guid(user.Id), otpCode);

                var email = new ForgetPasswdEmail()
                {
                    Subject = "Reset Your Password",
                    To = forgetPasswordDto.EmailAddress,
                    Body = $"Your OTP to reset the password is: {otpCode}"
                };

                // Use the SendEmail method with plain text message
                emailService.SendEmail(email.To, email.Subject, email.Body);

                return true;
            }

            return false;
        }

        public async Task<bool> VerifyOTP(OTPVerificationDto verificationDto)
        {
            string enteredOTP = verificationDto.EnteredOTP;

            var user = _userManager.Users.FirstOrDefault(u => u.Otp == enteredOTP);

            if (user != null && !string.IsNullOrEmpty(user.Otp) && user.Expire.HasValue && user.Expire > DateTime.Now)
            {
                if (enteredOTP.Equals(user.Otp, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (string.IsNullOrEmpty(resetPasswordDto.EmailAddress))
            {
                return false;
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordDto.EmailAddress);
            if (user == null)
            {
                return false;
            }

            bool isOTPValid = await VerifyOTP(new OTPVerificationDto { EnteredOTP = resetPasswordDto.OTP });

            if (isOTPValid)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, resetToken, resetPasswordDto.NewPassword);

                if (result.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        private async Task SaveOTPInDatabase(Guid userId, string otpCode)
        {
            try
            {
                var existingUser = _userManager.Users.FirstOrDefault(u => u.Id==userId.ToString());

                if (existingUser != null)
                {
                    existingUser.Otp = otpCode;
                    existingUser.Expire = DateTime.Now.AddMinutes(15);
                    await _userManager.UpdateAsync(existingUser);
                }
                else
                {
                    Console.WriteLine($"User not found for UserId: {userId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving OTP: {ex.Message}");
            }

        }
    }
}