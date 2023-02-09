using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.NutritionGoal
{
    public class UpdateNutritionGoalsRequest
    {
        [Required]
        public List<UpdateNutritionGoalRequest> NutritionGoals { get; set; }
    }
}
