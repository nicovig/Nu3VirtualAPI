using NuVirtualApi.Domain.Models.Request.Meal;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IMealBusiness
    {
        bool CreateMeal(CreateMealRequest request);
        bool DeleteMeal(int mealId);
        List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request);
        bool UpdateMeal(UpdateMealRequest request);
    }
}
