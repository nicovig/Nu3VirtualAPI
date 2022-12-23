using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.NutritionGoal
{
    public class GetAllNutritionGoalsByUserIdAndDateRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
