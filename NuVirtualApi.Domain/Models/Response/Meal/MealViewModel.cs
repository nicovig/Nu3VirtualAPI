using NuVirtualApi.Database.Enums;

namespace NuVirtualApi.Domain.Models.Response.Meal
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MealTypeEnum Type { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime Date { get; set; }
        public int Carbohydrate { get; set; }
        public int Lipid { get; set; }
        public int Protein { get; set; }
        public int Calorie { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    }
}
