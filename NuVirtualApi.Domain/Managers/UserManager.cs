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

        public UserModel AuthenticateUser(string login, string password)
        {
            UserModel result = null;

            User userDbEmail = _databaseContext.Users.Where(u => u.Email == login).FirstOrDefault();
            User userDbPseudo = _databaseContext.Users.Where(u => u.Pseudo == login).FirstOrDefault();

            User foundUser = null;

            if (userDbEmail != null)
            {
                foundUser = userDbEmail;
            }

            if (userDbPseudo != null)
            {
                foundUser = userDbPseudo;
            }

            if (foundUser.Password == PasswordTool.HashPassword(password))
            {
                result = new UserModel
                {
                    Id = foundUser.Id,
                    FirstName = foundUser.FirstName,
                    LastName = foundUser.LastName,
                    Gender = foundUser.Gender,
                    Birthday = foundUser.Birthday,
                    Height = foundUser.Height,
                    Weight = foundUser.Weight,
                    Pseudo = foundUser.Pseudo,
                    Email = foundUser.Email,
                    IsAdmin = foundUser.IsAdmin
                };
            }
            return result;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            User newUser = new User() 
            {
                Pseudo = request.Pseudo,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Birthday = request.Birthday,
                Height = request.Height,
                Weight = request.Weight,
                Email = request.Email,
                Password = PasswordTool.HashPassword(request.Password),
                IsAdmin = false
            };

            _databaseContext.Users.Add(newUser);
            int test = _databaseContext.SaveChanges();

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

            _databaseContext.ChangeTracker.Clear();
            _databaseContext.Update(user);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
