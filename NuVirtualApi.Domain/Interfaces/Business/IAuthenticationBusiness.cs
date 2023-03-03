using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Request.Authentication;
using NuVirtualApi.Domain.Models.Response.Authentication;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IAuthenticationBusiness
    {
        TokenModel ConnectUser(ConnectUserRequest request);
        ResetPasswordResponse ResetPassword(string email);
    }
}
