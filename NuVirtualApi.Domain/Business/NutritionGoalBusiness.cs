using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Managers;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.View;

namespace NuVirtualApi.Domain.Business
{

    public class NutritionGoalBusiness : INutritionGoalBusiness
    {
        public INutritionGoalManager _nutritionGoalManager;

        public NutritionGoalBusiness(INutritionGoalManager nutritionGoalManager)
        {
            _nutritionGoalManager = nutritionGoalManager;
        }

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request)
        {
            return _nutritionGoalManager.GetAllNutritionGoalsByUserIdAndDate(request);
        }

        public bool UpdateNutritionGoal(UpdateNutritionGoalRequest request)
        {
            return _nutritionGoalManager.UpdateNutritionGoal(request);
        }
    }
}
