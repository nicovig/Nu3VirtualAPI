﻿using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Request.User;
using NuVirtualApi.Domain.Models.Response.User;

public interface IUserManager
{
    UserModel AuthenticateUser(string login, string password);
    bool ChangePassword(int userId, string oldPassword, string newPassword);
    CreateUserResponse CreateUser(CreateUserRequest request);
    bool IsEmailUsable(string email);
    UpdateUserResponse UpdateUser(UpdateUserRequest request);
}