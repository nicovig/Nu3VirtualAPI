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
            throw new NotImplementedException();
        }

        public bool DeleteMeal(int mealId)
        {
            throw new NotImplementedException();
        }

        public List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMeal(UpdateMealRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
