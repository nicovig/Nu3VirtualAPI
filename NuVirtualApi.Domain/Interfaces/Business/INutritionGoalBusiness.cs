using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.View;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface INutritionGoalBusiness
    {
        List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request);
        bool UpdateNutritionGoal(UpdateNutritionGoalRequest request);
    }
}
