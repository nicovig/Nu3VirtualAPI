using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Request;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IAuthenticationBusiness
    {
        TokenModel ConnectUser(ConnectUserRequest request);
    }
}
