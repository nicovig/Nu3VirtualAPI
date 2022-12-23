using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface INutritionGoalBusiness
    {
        bool CreateDefaultNutritionGoals(CreateDefaultNutritionGoalsRequest request);
        List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request);
        bool UpdateNutritionGoal(UpdateNutritionGoalRequest request);
    }
}
