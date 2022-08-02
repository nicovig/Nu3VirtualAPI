using NuVirtualApi.Database;
using NuVirtualApi.Domain.Models;

namespace NuVirtualApi.Domain.Managers
{
    public class UserManager : IUserManager
    {
        private readonly DatabaseContext _databaseContext;

        public UserManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public UserModel AuthenticateUser(string email, string password)
        {
            UserModel result = null;
            var userDb = _databaseContext.Users.Where(t => t.Email == email).FirstOrDefault();

            if (userDb != null && userDb.Password == PasswordTool.HashPassword(password))
            {
                result = new UserModel
                {
                    Id = userDb.Id,
                    FirstName = userDb.FirstName,
                    LastName = userDb.LastName,
                    Birthday = userDb.Birthday,
                    Height = userDb.Height,
                    Weight = userDb.Weight,
                    Pseudo = userDb.Pseudo,
                    Email = userDb.Email
                };
            }
            return result;
        }
    }
}
