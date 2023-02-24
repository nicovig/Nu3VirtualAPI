using NuVirtualApi.Database.Enums;

namespace NuVirtualApi.Domain.Models.Response.NutritionGoal
{
    public class NutritionGoalViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public MacronutrientTypeEnum Type { get; set; }
        public DateTime Date { get; set; }
        public int AchievedValue { get; set; }
        public double AchievedRatio { get; set; }
        public int TotalValue { get; set; }
        public bool IsActive { get; set; }
    }
}
