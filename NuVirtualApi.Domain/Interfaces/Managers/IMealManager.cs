using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Response.Meal;

namespace NuVirtualApi.Domain.Interfaces.Manager
{
    public interface IMealManager
    {
        int CreateMeal(CreateMealRequest request);
        bool DeleteMeal(int mealId);
        List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request);
        MealViewModel GetMealByMealId(int mealId);
        bool UpdateMeal(UpdateMealRequest request);
        bool UpdateIsFavoriteByFavoriteMealId(int mealId);
    }
}
