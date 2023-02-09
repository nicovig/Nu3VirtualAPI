using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Request.User;
using NuVirtualApi.Domain.Models.Response.User;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IUserBusiness
    {
        bool ChangePassword(int userId, string oldPassword, string newPassword);
        CreateUserResponse CreateUser(CreateUserRequest request);
        bool UpdateUser(UpdateUserRequest request);
    }
}
