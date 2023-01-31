using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Response.Meal;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IMealBusiness
    {
        bool CreateMeal(CreateMealRequest request);
        bool DeleteMeal(int mealId);
        List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request);
        MealViewModel GetMealByMealId(int mealId);
        bool UpdateMeal(UpdateMealRequest request);
    }
}
