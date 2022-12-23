using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.Meal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;

namespace NuVirtualApi.Domain.Interfaces.Managers
{
    public interface INutritionGoalManager
    {
        bool CreateDefaultNutritionGoals(CreateDefaultNutritionGoalsRequest request);
        List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request, List<MealViewModel> mealsByDate);
        bool UpdateNutritionGoal(UpdateNutritionGoalRequest request);
    }
}
