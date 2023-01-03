using Microsoft.Extensions.Options;
using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Config;
using NuVirtualApi.Domain.Models.Request.User;
using NuVirtualApi.Domain.Models.Response.User;
using NuVirtualApi.Domain.Tools;

namespace NuVirtualApi.Domain.Managers
{
    public class UserManager : IUserManager
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public UserManager(DatabaseContext databaseContext, IOptions<JwtSettings> jwtSettings)
        {
            _databaseContext = databaseContext;
            _jwtSettings = jwtSettings;
        }

        public UserModel AuthenticateUser(string email, string password)
        {
            UserModel result = null;
            User userDb = _databaseContext.Users.Where(u => u.Email == email).FirstOrDefault();

            if (userDb != null && userDb.Password == PasswordTool.HashPassword(password))
            {
                result = new UserModel
                {
                    Id = userDb.Id,
                    FirstName = userDb.FirstName,
                    LastName = userDb.LastName,
                    Gender = userDb.Gender,
                    Birthday = userDb.Birthday,
                    Height = userDb.Height,
                    Weight = userDb.Weight,
                    Pseudo = userDb.Pseudo,
                    Email = userDb.Email,
                    IsAdmin = userDb.IsAdmin
                };
            }
            return result;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            User newUser = new User() 
            {
                Pseudo = request.User.Pseudo,
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                Gender = request.User.Gender,
                Birthday = request.User.Birthday,
                Height = request.User.Height,
                Weight = request.User.Weight,
                Email = request.User.Email,
                Password = PasswordTool.HashPassword(request.User.Password),
                IsAdmin = false
            };

            _databaseContext.Users.Add(newUser);
            _databaseContext.SaveChanges();

            UserModel userToResponse = new UserModel()
            {
                Id = newUser.Id,
                Pseudo = newUser.Pseudo,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Gender = newUser.Gender,
                Birthday = newUser.Birthday,
                Height = newUser.Height,
                Weight = newUser.Weight,
                Email = newUser.Email,
                Password = newUser.Password,
                IsAdmin = false
            };

            return new CreateUserResponse()
            {
                Token = TokenTool.GenerateJwt(userToResponse, _jwtSettings.Value),
                User = userToResponse
            };
        }

        public bool UpdateUser(UpdateUserRequest request)
        {
            User user = _databaseContext.Users.Where(u => u.Id == request.Id).FirstOrDefault();

            if (user == null) return false;

            user = new User()
            {
                Id = request.Id,
                Pseudo = request.Pseudo,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Birthday = request.Birthday,
                Height = request.Height,
                Weight = request.Weight,
                Email = request.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };

            _databaseContext.Update(user);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
