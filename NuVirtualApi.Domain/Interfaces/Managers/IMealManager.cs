using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Response.Meal;

namespace NuVirtualApi.Domain.Interfaces.Manager
{
    public interface IMealManager
    {
        bool CreateMeal(CreateMealRequest request);
        bool DeleteMeal(int mealId);
        List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request);
        bool UpdateMeal(UpdateMealRequest request);
    }
}
