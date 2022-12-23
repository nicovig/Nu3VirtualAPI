using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Managers;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;

namespace NuVirtualApi.Domain.Business
{
    public class NutritionGoalBusiness : INutritionGoalBusiness
    {
        public INutritionGoalManager _nutritionGoalManager;
        //public IMealManager _mealManager;

        //public NutritionGoalBusiness(IMealManager mealManager, INutritionGoalManager nutritionGoalManager)
        public NutritionGoalBusiness(INutritionGoalManager nutritionGoalManager)
        {
            //_mealManager = mealManager;
            _nutritionGoalManager = nutritionGoalManager;
        }

        public bool CreateDefaultNutritionGoals(CreateDefaultNutritionGoalsRequest request)
        {
            return _nutritionGoalManager.CreateDefaultNutritionGoals(request);
        }

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request)
        {
            //List<Meal> mealsByDate = _mealManager.GetAllMealsByUserIdAndDate(new GetAllMealsByUserIdAndDateRequest()
            //{
            //    UserId = request.UserId,
            //    Date = request.Date,
            //});

            List<Meal> mealsByDate = new List<Meal>();
            return _nutritionGoalManager.GetAllNutritionGoalsByUserIdAndDate(request, mealsByDate);
        }

        public bool UpdateNutritionGoal(UpdateNutritionGoalRequest request)
        {
            return _nutritionGoalManager.UpdateNutritionGoal(request);
        }
    }
}
