using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Request.Authentication;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IAuthenticationBusiness
    {
        TokenModel ConnectUser(ConnectUserRequest request);
    }
}
