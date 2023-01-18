using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Response.Meal;

namespace NuVirtualApi.Domain.Business
{
    public class MealBusiness : IMealBusiness
    {
        public IMealManager _mealManager;

        public MealBusiness(IMealManager mealManager)
        {
            _mealManager = mealManager;
        }

        public bool CreateMeal(CreateMealRequest request)
        {
            return _mealManager.CreateMeal(request);
        }

        public bool DeleteMeal(int mealId)
        {
            return _mealManager.DeleteMeal(mealId);
        }

        public List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request)
        {
            return _mealManager.GetAllMealsByUserIdAndDate(request);
        }

        public MealViewModel GetMealByMealId(int mealId)
        {
            return _mealManager.GetMealByMealId(mealId);
        }

        public bool UpdateMeal(UpdateMealRequest request)
        {
            return _mealManager.UpdateMeal(request);
        }
    }
}
