

using Infrastructure.Authentication;

namespace Infrastructure.Services
{
    public interface IAuthService
    {

        Task<AuthModel> RegisterAsync(RegisterModel registerModel);
		Task<AuthModel> GetTokenAsync(TokenRequestModel model);
		Task<string> AddRoleAsync(AddRoleModel model);
        Task<bool> ForgetPasswordEmail(ForgetPasswordDto forgetPasswordDto);
        Task<bool> VerifyOTP(OTPVerificationDto verificationDto);
        Task<bool> ResetPassword(ResetPasswordDto resetPasswordDto);

	}
}
