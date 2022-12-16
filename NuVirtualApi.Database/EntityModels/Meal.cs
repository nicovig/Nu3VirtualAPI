using NuVirtualApi.Database.Enums;

namespace NuVirtualApi.Database.EntityModels
{
    public class Meal
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
		public User User { get; set; }
	}
}
