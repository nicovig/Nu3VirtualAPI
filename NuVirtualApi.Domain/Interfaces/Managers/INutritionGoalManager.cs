using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.View;

namespace NuVirtualApi.Domain.Interfaces.Managers
{
    public interface INutritionGoalManager
    {
        List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request);
        bool UpdateNutritionGoal(UpdateNutritionGoalRequest request);
    }
}
