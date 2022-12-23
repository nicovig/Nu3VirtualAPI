using NuVirtualApi.Database.Enums;

namespace NuVirtualApi.Database.EntityModels
{
    public class NutritionGoal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MacronutrientTypeEnum Type { get; set; }
        public int Order { get; set; }
        public int TotalValue { get; set; }
        public User User { get; set; }
    }
}
