
namespace NuVirtualApi.Domain.Models.Response.Authentication
{
    public class ResetPasswordResponse
    {
        public bool IsPasswordReset { get; set; }
        public bool IsUserExist { get; set; }
        public bool IsEmailSent { get; set; }
        
    }
}
