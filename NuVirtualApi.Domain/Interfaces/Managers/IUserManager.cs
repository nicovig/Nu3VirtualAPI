using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Request.User;
using NuVirtualApi.Domain.Models.Response.User;

public interface IUserManager
{
    UserModel AuthenticateUser(string mail, string password);
    CreateUserResponse CreateUser(CreateUserRequest request);
    bool UpdateUser(UpdateUserRequest request);
}