using NuVirtualApi.Domain.Models;

public interface IUserManager
{
    UserModel AuthenticateUser(string mail, string password);
}