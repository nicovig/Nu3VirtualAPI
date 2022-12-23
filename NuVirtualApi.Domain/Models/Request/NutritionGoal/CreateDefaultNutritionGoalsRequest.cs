using NuVirtualApi.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.NutritionGoal
{
    public class CreateDefaultNutritionGoalsRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }
    }
}
