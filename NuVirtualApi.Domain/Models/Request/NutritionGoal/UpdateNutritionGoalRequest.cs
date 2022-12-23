using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.NutritionGoal
{
    public class UpdateNutritionGoalRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public int TotalValue { get; set; }
    }
}
