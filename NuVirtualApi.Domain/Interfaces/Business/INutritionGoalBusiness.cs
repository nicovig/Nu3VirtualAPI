using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface INutritionGoalBusiness
    {
        List<NutritionGoalViewModel> GetAllNutritionGoalsByUserId(int userId);
        List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request);
        bool UpdateNutritionGoal(UpdateNutritionGoalsRequest request);
    }
}
