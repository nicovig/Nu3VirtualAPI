using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Managers;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Request.User;
using NuVirtualApi.Domain.Models.Response.User;

namespace NuVirtualApi.Domain.Business
{
    public class UserBusiness : IUserBusiness
    {
        public INutritionGoalManager _nutritionGoalManager;
        public IUserManager _userManager;

        public UserBusiness(INutritionGoalManager nutritionGoalManager, IUserManager userManager)
        {
            _nutritionGoalManager = nutritionGoalManager;
            _userManager = userManager;
        }

        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            return _userManager.ChangePassword(userId, oldPassword, newPassword);
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse createUserResponse = _userManager.CreateUser(request);

            bool isCreateDefaultNutritionGoalsOk = _nutritionGoalManager.CreateDefaultNutritionGoals(new CreateDefaultNutritionGoalsRequest()
            {
                Gender = createUserResponse.User.Gender,
                UserId = createUserResponse.User.Id
            });

            if (!isCreateDefaultNutritionGoalsOk)
            {
                throw new Exception("Erreur lors de la création des objectifs par défaut");
            }

            return createUserResponse;
        }

        public bool IsUserExistByLogin(string login)
        {
            return _userManager.IsUserExistByLogin(login);
        }

        public bool IsUserExistByMail(string email)
        {
            return _userManager.IsUserExistByMail(email);
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            return _userManager.UpdateUser(request);
        }
    }
}
