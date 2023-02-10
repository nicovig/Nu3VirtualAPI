using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Response.Meal;

namespace NuVirtualApi.Domain.Business
{
    public class MealBusiness : IMealBusiness
    {
        public IFavoriteMealManager _favoriteMealManager;
        public IMealManager _mealManager;

        public MealBusiness(IFavoriteMealManager favoriteMealManager, IMealManager mealManager)
        {
            _favoriteMealManager = favoriteMealManager;
            _mealManager = mealManager;
        }

        public bool CreateMeal(CreateMealRequest request)
        {
            int mealId = _mealManager.CreateMeal(request);

            if (mealId == 0)
            {
                return false;
            }

            bool treatmentIsOk = _favoriteMealManager.CreateFavoriteMeal(mealId, request.UserId);

            return treatmentIsOk; 
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
            bool updateIsOk = _mealManager.UpdateMeal(request);

            if (!updateIsOk)
            {
                return false;
            }

            bool favoriteMealTreatmentIsOk = _favoriteMealManager.UpdateFavoriteMealByMealId(request.Id, request.UserId);

            return favoriteMealTreatmentIsOk;
        }
    }
}
